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
        private IUnitOfWork DB { get; set; }

        public TopicService(IUnitOfWork database)
        {
            DB = database;
        }

        public IEnumerable<TopicDTO> GetAllElements()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<Topic, TopicDTO>());

            return Mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(DB.Topics.GetAllElements());
        }

        public TopicDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("????????", "");      //нельзя писать, что id не установлен. надо придумать текст
            }

            var topic = DB.Topics.GetElement(id.Value);
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
                DateOfCreate = element.DateOfCreate
            };

            DB.Topics.Create(topic);
            DB.SaveChanges();
        }

        public void UpdateElement(TopicDTO element)
        {
            Topic topic = new Topic
            {
                Header = element.Header,
                Description = element.Description,
                DateOfCreate = element.DateOfCreate
            };

            DB.Topics.Update(topic);
            DB.SaveChanges();
        }

        public void DeleteElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }

            DB.Products.Delete(id.Value);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
