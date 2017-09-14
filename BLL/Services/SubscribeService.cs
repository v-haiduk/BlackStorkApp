using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    public class SubscribeService: IMainService<SubscribeDTO>
    {
        private IUnitOfWork uow { get; set; }

        public SubscribeService(IUnitOfWork database)
        {
            uow = database;
        }

        /// <summary>
        /// The method gets all email from DB and transfer them on PL
        /// </summary>
        public IEnumerable<SubscribeDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Subscribe, SubscribeDTO>());

            return Mapper.Map<IEnumerable<Subscribe>, IEnumerable<SubscribeDTO>>(uow.Subscribs.GetAllElements());
        }

        /// <summary>
        /// The method finds the subscribe by predicate
        /// </summary>
        /// <param name="predicate">The Predicate for search</param>
        /// <returns>The subscribe, which the e-mail coincides with the predicate</returns>
        public IEnumerable<SubscribeDTO> FindElement(Expression<Func<SubscribeDTO, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ValidationException("Извините, email не найден", "");
            }
            var predicateCompile = predicate.Compile();
            var resultOfFind = GetAllElements().Where(predicateCompile);

            return resultOfFind;
        }

        /// <summary>
        /// The method gets the email from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of email</param>
        public SubscribeDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id email", "");
            }

            var email = uow.Subscribs.GetElement(id.Value);
            if (email == null)
            {
                throw new ValidationException("Извите, такой email не найден", "");
            }
            Mapper.Initialize(configuration => configuration.CreateMap<Subscribe, SubscribeDTO>());

            return Mapper.Map<Subscribe, SubscribeDTO>(email);

        }

        /// <summary>
        /// The method gets the new email from PL and save it in DB
        /// </summary>
        /// <param name="element">Thew new email</param>
        public void CreateElement(SubscribeDTO element)
        {
            Subscribe email = new Subscribe
            {
                Email = element.Email
            };
            uow.Subscribs.Create(email);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated email from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated email</param>
        public void UpdateElement(SubscribeDTO element)
        {
            Subscribe email = new Subscribe
            {
                SubscribeId = element.SubscribeId,
                Email = element.Email
            };
            uow.Subscribs.Update(email);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of email from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of email for delete</param>
        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id email", "");
            }
            uow.Subscribs.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
