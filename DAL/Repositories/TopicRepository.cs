using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class TopicRepository : IRepository<Topic>
    {
        private BlackStorkContext db;

        public TopicRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        public IEnumerable<Topic> GetAllElements()
        {
            return db.Topics;
        }

        public Topic GetElement(int id)
        {
            return db.Topics.Find(id);
        }

        public IEnumerable<Topic> FindElement(Func<Topic, bool> predicate)
        {
            return db.Topics.Where(predicate).ToList();
        }

        public void Create(Topic item)
        {
            db.Topics.Add(item);
        }

        public void Delete(int id)
        {
            var topicForDelete = db.Topics.Find(id);
            if (topicForDelete != null)
            {
                db.Topics.Remove(topicForDelete);
            }
        }

        public void Update(Topic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
