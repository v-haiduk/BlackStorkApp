using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    public class SubscribeRepository: IRepository<Subscribe>
    {
        private BlackStorkContext db;
        public SubscribeRepository(BlackStorkContext database)
        {
            db = database;
        }

        /// <summary>
        /// The method gets all subscribers from DB
        /// </summary>
        /// <returns>The collection of subscribers</returns>
        public IEnumerable<Subscribe> GetAllElements()
        {
            return db.Subcribs;
        }

        /// <summary>
        /// The method gets the subscribe from DB
        /// </summary>
        /// <param name="id">The id of subscribe</param>
        /// <returns>The subcribe with the requested id</returns>
        public Subscribe GetElement(int id)
        {
            return db.Subcribs.Find(id);
        }

        /// <summary>
        /// The method finds the subcribe by predicate
        /// </summary>
        /// <param name="predicate">The Predicate for search</param>
        /// <returns>The subscribe, which the e-mail coincides with the predicate</returns>
        public IEnumerable<Subscribe> FindElement(Expression<Func<Subscribe, bool>> predicate)
        {
            return db.Subcribs.Where(predicate);
        }

        /// <summary>
        /// The method gets the new subscribe and adds it in DB
        /// </summary>
        /// <param name="item">The new subscribe</param>
        public void Create(Subscribe item)
        {
            db.Subcribs.Add(item);
        }

        /// <summary>
        /// The method deletes the subscribe from DB
        /// </summary>
        /// <param name="id">The id of subscribe,which will be deleted</param>
        public void Delete(int id)
        {
            var emailForDelete = db.Subcribs.Find(id);
            if (emailForDelete != null)
            {
                db.Subcribs.Remove(emailForDelete);
            }
        }

        /// <summary>
        /// The method gets the updated subscribe and modified old record
        /// </summary>
        /// <param name="item">The updated subscribe</param>
        public void Update(Subscribe item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
