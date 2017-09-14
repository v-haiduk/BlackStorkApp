using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// The implementation of IRepository
    /// </summary>
    class TopicRepository : IRepository<Topic>
    {
        private BlackStorkContext db;

        public TopicRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        /// <summary>
        /// The method gets all topics from DB
        /// </summary>
        /// <returns>The collection of topics</returns>
        public IEnumerable<Topic> GetAllElements()
        {
            return db.Topics;
        }

        /// <summary>
        /// The method gets the topic from DB
        /// </summary>
        /// <param name="id">The id of topic</param>
        /// <returns>The topic with the requested id</returns>
        public Topic GetElement(int id)
        {
            return db.Topics.Find(id);
        }

        /// <summary>
        /// The method finds the topic by predicate
        /// </summary>
        /// <param name="predicate">The Predicate for search</param>
        /// <returns>The topic, which the name coincides with the predicate</returns>
        public IEnumerable<Topic> FindElement(Expression<Func<Topic, bool>> predicate)
        {
            return db.Topics.Where(predicate).Select(i => i);
        }

        /// <summary>
        /// The method gets the new topic and adds it in DB
        /// </summary>
        /// <param name="item">The new topic</param>
        public void Create(Topic item)
        {
            db.Topics.Add(item);
        }

        /// <summary>
        /// The method deletes the topic from DB
        /// </summary>
        /// <param name="id">The id of topic,which will be deleted</param>
        public void Delete(int id)
        {
            var topicForDelete = db.Topics.Find(id);
            if (topicForDelete != null)
            {
                db.Topics.Remove(topicForDelete);
            }
        }

        /// <summary>
        /// The method gets the updated topic and modified old record
        /// </summary>
        /// <param name="item">The updated topic</param>
        public void Update(Topic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
