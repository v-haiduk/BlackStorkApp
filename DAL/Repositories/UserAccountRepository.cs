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
    class UserAccountRepository : IRepository<UserAccount>
    {
        private BlackStorkContext db;

        public UserAccountRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        public IEnumerable<UserAccount> GetAllElements()
        {
            return db.UserAccounts;
        }

        public UserAccount GetElement(int id)
        {
            return db.UserAccounts.Find(id);
        }

        public IEnumerable<UserAccount> FindElement(Expression<Func<UserAccount, bool>> predicate)
        {
            return db.UserAccounts.Where(predicate).Select(i=>i);
        }

        public void Create(UserAccount item)
        {
            db.UserAccounts.Add(item);
        }

        public void Delete(int id)
        {
            var accountForDelete = db.UserAccounts.Find(id);
            if (accountForDelete != null)
            {
                db.UserAccounts.Remove(accountForDelete);
            }
        }

        public void Update(UserAccount item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
