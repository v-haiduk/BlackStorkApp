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
    class EmailSendingRepository : IRepository<Subscribe>
    {
        private BlackStorkContext db;

        public EmailSendingRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        public IEnumerable<Subscribe> GetAllElements()
        {
            return db.Subscribes;
        }

        public Subscribe GetElement(int id)
        {
            return db.Subscribes.Find(id);
        }

        public IEnumerable<Subscribe> FindElement(Expression<Func<Subscribe, bool>> predicate)
        {
            return db.Subscribes.Where(predicate).Select(i => i);
        }

        public void Create(Subscribe item)
        {
            db.Subscribes.Add(item);
        }

        public void Delete(int id)
        {
            var profileForDelete = db.Subscribes.Find(id);
            if (profileForDelete != null)
            {
                db.Subscribes.Remove(profileForDelete);
            }
        }

        public void Update(Subscribe item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
