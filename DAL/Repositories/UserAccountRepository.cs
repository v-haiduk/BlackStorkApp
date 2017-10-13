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

        /// <summary>
        /// The method gets all accounts from DB
        /// </summary>
        /// <returns>The collection of accounts</returns>
        public IEnumerable<UserAccount> GetAllElements()
        {
            return db.UserAccounts;
        }

        /// <summary>
        /// The method gets the account from DB
        /// </summary>
        /// <param name="id">The id of account</param>
        /// <returns>The account with the requested id</returns>
        public UserAccount GetElement(int id)
        {
            return db.UserAccounts.Find(id);
        }

        /// <summary>
        /// The method finds the account by predicate
        /// </summary>
        /// <param name="predicate">The Predicate for search</param>
        /// <returns>The account, which the name coincides with the predicate</returns>
        public IEnumerable<UserAccount> FindElement(Expression<Func<UserAccount, bool>> predicate)
        {
            return db.UserAccounts.Where(predicate).Select(i=>i);
        }

        /// <summary>
        /// The method gets the new account and adds it in DB
        /// </summary>
        /// <param name="item">The new account</param>
        public void Create(UserAccount item)
        {
            db.UserAccounts.Add(item);
        }

        /// <summary>
        /// The method deletes the account from DB
        /// </summary>
        /// <param name="id">The id of account,which will be deleted</param>
        public void Delete(int id)
        {
            var accountForDelete = db.UserAccounts.Find(id);
            if (accountForDelete != null)
            {
                db.UserAccounts.Remove(accountForDelete);
            }
        }

        /// <summary>
        /// The method gets the updated account and modified old record
        /// </summary>
        /// <param name="item">The updated account</param>
        public void Update(UserAccount item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
