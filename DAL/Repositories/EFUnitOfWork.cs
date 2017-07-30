﻿using System;
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
        private EmailSendingRepository emailSendingRepository;

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

        public IRepository<Subscribe> EmailSendings
        {
            get
            {
                if (emailSendingRepository == null)
                {
                    emailSendingRepository = new EmailSendingRepository(db);
                }
                return emailSendingRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
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
