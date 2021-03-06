﻿using System;
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
    class UserProfileRepository : IRepository<UserProfile>
    {
        private BlackStorkContext db;

        public UserProfileRepository(BlackStorkContext blackStorkContext)
        {
            this.db = blackStorkContext;
        }

        public IEnumerable<UserProfile> GetAllElements()
        {
            return db.UserProfiles;
        }

        public UserProfile GetElement(int id)
        {
            return db.UserProfiles.Find(id);
        }

        public IEnumerable<UserProfile> FindElement(Expression<Func<UserProfile, bool>> predicate)
        {
            return db.UserProfiles.Where(predicate).Select(i => i);
        }

        public void Create(UserProfile item)
        {
            db.UserProfiles.Add(item);
        }

        public void Delete(int id)
        {
            var profileForDelete = db.UserProfiles.Find(id);
            if (profileForDelete != null)
            {
                db.UserProfiles.Remove(profileForDelete);
            }
        }

        public void Update(UserProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
