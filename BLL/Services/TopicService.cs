using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    /// <summary>
    /// The class implements the interface IMainService.
    /// </summary>
    public class TopicService : IMainService<TopicDTO>
    {
        private IUnitOfWork uow { get; set; }

        public TopicService(IUnitOfWork database)
        {
            uow = database;
        }

        /// <summary>
        /// The method gets all topics from DB and transfer them on PL
        /// </summary>
        public IEnumerable<TopicDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Topic, TopicDTO>());

            return Mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(uow.Topics.GetAllElements());
        }

        public IEnumerable<TopicDTO> FindElement(Expression<Func<TopicDTO, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ValidationException("Извините, данная статья не найдена", "");
            }
            var predicateCompile = predicate.Compile();
            var resultOfFind = GetAllElements().Where(predicateCompile);

            return resultOfFind;
        }

        /// <summary>
        /// The method gets the topic from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of topic</param>
        public TopicDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id статьи ", "");  
            }

            var topic = uow.Topics.GetElement(id.Value);
            if (topic == null)
            {
                throw new ValidationException("Извините, данная статья не найдена", "");
            }

            Mapper.Initialize(configuration => configuration.CreateMap<Topic, TopicDTO>());

            return Mapper.Map<Topic, TopicDTO>(topic);
        }

        /// <summary>
        /// The method gets the new topic from PL and save it in DB
        /// </summary>
        /// <param name="item">Thew new topic</param>
        public void CreateElement(TopicDTO element)
        {
            Topic topic = new Topic
            {
                Header = element.Header,
                Description = element.Description,
                DateOfCreate = element.DateOfCreate,
                PathForMainPhoto = element.PathForMainPhoto,
                PathForFolderWithPhotos = element.PathForFolderWithPhotos
            };

            uow.Topics.Create(topic);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated topic from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated topic</param>
        public void UpdateElement(TopicDTO element)
        {
            Topic topic = new Topic
            {
                TopicId = element.TopicId,
                Header = element.Header,
                Description = element.Description,
                DateOfCreate = element.DateOfCreate,
                PathForMainPhoto = element.PathForMainPhoto,
                PathForFolderWithPhotos = element.PathForFolderWithPhotos
            };

            uow.Topics.Update(topic);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of topic from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of topic for delete</param>
        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id стать ", "");
            }

            uow.Topics.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
