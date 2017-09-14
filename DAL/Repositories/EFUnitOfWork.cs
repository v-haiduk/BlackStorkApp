using System;
using System.Data.Entity.Infrastructure;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// The class is needed, that all repositories use one context of data.
    /// Through this class, we will work with DB.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlackStorkContext db;
        private ProductRepository productRepository;
        private TopicRepository topicRepository;
        private UserAccountRepository userAccountRepository;
        private UserProfileRepository userProfileRepository;
        private SubscribeRepository subscribeRepository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EFUnitOfWork()
        {
            db = new BlackStorkContext();
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicRepository == null)
                {
                    topicRepository = new TopicRepository(db);
                }
                return topicRepository;
            }
        }

        public IRepository<UserAccount> UsersAccounts
        {
            get
            {
                if (userAccountRepository == null)
                {
                    userAccountRepository = new UserAccountRepository(db);
                }
                return userAccountRepository;
            }
        }

        public IRepository<UserProfile> UsersProfiles
        {
            get
            {
                if (userAccountRepository == null)
                {
                    userProfileRepository = new UserProfileRepository(db);
                }
                return userProfileRepository;
            }
        }

        public IRepository<Subscribe> Subscribs
        {
            get
            {
                if (subscribeRepository == null)
                {
                    subscribeRepository = new SubscribeRepository(db);
                }
                return subscribeRepository;
            }
            
        }

        /// <summary>
        /// The method saves all changes. 
        /// </summary>
        public void SaveChanges()
        {           
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                logger.Error("The error occurred while saving changes to the database: {0}", ex);
            }           
        }

        //Implementation of combined template
        private bool disposed = false;

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
