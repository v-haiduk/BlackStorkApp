using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Topic> Topics { get; }
        IRepository<UserAccount> UsersAccounts { get; }
        IRepository<UserProfile> UsersProfiles { get; }
        void SaveChanges();
    }
}
