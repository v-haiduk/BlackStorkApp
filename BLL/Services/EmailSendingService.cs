using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    /// <summary>
    /// The class implements the interface IMainService.
    /// This class needs for work with subscribe.
    /// </summary>
    public class EmailSendingService: IMainService<EmailSendingDTO>
    {
        IUnitOfWork uow { get; set; }

        //EFUnitOfWork will be used as the object of the IUnitOfWork
        public EmailSendingService (IUnitOfWork database)
        {
            uow = database;
        }

        /// <summary>
        /// The method gets all email from DB and transfer them on PL
        /// </summary>
        public IEnumerable<EmailSendingDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<EmailSending, EmailSendingDTO>());

            return Mapper.Map<IEnumerable<EmailSending>, IEnumerable<EmailSendingDTO>>(uow.EmailSendings.GetAllElements());
        }

        public IEnumerable<EmailSendingDTO> FindElement(Expression<Func<EmailSendingDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method gets the email from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of email</param>
        public EmailSendingDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id email для рассылки", "");
            }

            var email = uow.EmailSendings.GetElement(id.Value);
            if (email == null)
            {
                throw new ValidationException("Извините, данный email не найден", "");
            }
            Mapper.Initialize(configuration => configuration.CreateMap<EmailSending, EmailSendingDTO>());

            return Mapper.Map<EmailSending, EmailSendingDTO>(email);
        }

        /// <summary>
        /// The method gets the new email from PL and save it in DB
        /// </summary>
        /// <param name="element">Thew new email</param>
        public void CreateElement(EmailSendingDTO element)
        {
            EmailSending email = new EmailSending
            {
                EmailSendingId = element.EmailSendingId,
                Email = element.Email
            };

            uow.EmailSendings.Create(email);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated email from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated email</param>
        public void UpdateElement(EmailSendingDTO element)
        {
            EmailSending email = new EmailSending
            {
                Email = element.Email
            };
            uow.EmailSendings.Update(email);
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
                throw new ValidationException("Не установлен id email для рассылки", "");
            }
            uow.EmailSendings.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
