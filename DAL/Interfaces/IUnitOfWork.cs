using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    /// <summary>
    /// The interface is needed to work within the same business action.
    /// The data is expected, modified and saved on the end.
    /// The IDisposable is inherited for closed the connection.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Topic> Topics { get; }
        IRepository<UserAccount> UsersAccounts { get; }
        IRepository<UserProfile> UsersProfiles { get; }
        void SaveChanges();
    }
}
