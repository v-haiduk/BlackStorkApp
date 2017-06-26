using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    /// <summary>
    /// The class implements the interface IUserService.
    /// </summary>
    public class UserService: IUserService
    {
        IUnitOfWork uow { get; set; }

        public UserService(IUnitOfWork database)
        {
            uow = database;
        }

        /// <summary>
        /// The method gets all accounts of users from DB and transfer them on PL
        /// </summary>
        public IEnumerable<UserAccountDTO> GetAllElements()
        {
            Mapper.Initialize(configutation => configutation.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<IEnumerable<UserAccount>, IEnumerable<UserAccountDTO>>(uow.UsersAccounts.GetAllElements());
        }

        public IEnumerable<UserAccountDTO> FindElement(Expression<Func<UserAccountDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method gets the account of user from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of user</param>
        public UserAccountDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id пользователя ", "");      
            }

            var account = uow.UsersAccounts.GetElement(id.Value);
            if (account == null)
            {
                throw new ValidationException("Извините, данный пользователь не найден", "");
            }
            Mapper.Initialize(configutation => configutation.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<UserAccount, UserAccountDTO>(account);
        }

        /// <summary>
        /// The method gets the new account of user from PL and save it in DB
        /// </summary>
        /// <param name="element">Thew new account</param>
        public void CreateElement(UserAccountDTO element)
        {
            UserAccount account = new UserAccount
            {
                UserAccountId = element.UserId,
                Login = element.Login,
                HashOfPassword = element.HashOfPassword
            };
            uow.UsersAccounts.Create(account);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated account of user from PL and save it in DB
        /// </summary>
        /// <param name="element">The updated account</param>
        public void UpdateElement(UserAccountDTO element)
        {
            UserAccount account = new UserAccount
            {
                UserAccountId = element.UserId,
                Login = element.Login,
                HashOfPassword = element.HashOfPassword
            };
            uow.UsersAccounts.Update(account);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of user's account from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of account for delete</param>
        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id пользователя ", ""); 
            }
            uow.UsersAccounts.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        /// <summary>
        /// Method finds a user by login
        /// </summary>
        /// <param name="login">The user's login</param>
        public UserAccountDTO GetByLogin(string login)
        {
            var requestedUser = uow.UsersAccounts.FindElement(user => user.Login == login).FirstOrDefault();
            Mapper.Initialize(configutation => configutation.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<UserAccount, UserAccountDTO>(requestedUser);
        }
    }
}
