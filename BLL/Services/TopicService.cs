using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    public class TopicService : IMainService<TopicDTO>
    {
        private IUnitOfWork uow { get; set; }

        public TopicService(IUnitOfWork database)
        {
            uow = database;
        }

        public IEnumerable<TopicDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Topic, TopicDTO>());

            return Mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(uow.Topics.GetAllElements());
        }

        public TopicDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("????????", "");      //нельзя писать, что id не установлен. надо придумать текст
            }

            var topic = uow.Topics.GetElement(id.Value);
            if (topic == null)
            {
                throw new ValidationException("Извините, но ничего не найдено", "");
            }

            Mapper.Initialize(configuration => configuration.CreateMap<Topic, TopicDTO>());

            return Mapper.Map<Topic, TopicDTO>(topic);
        }

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

        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
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
