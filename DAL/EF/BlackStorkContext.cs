using System;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    class BlackStorkContext : DbContext
    {
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        static BlackStorkContext()
        {
            Database.SetInitializer<BlackStorkContext>(new BlackStorkDbInitializer());
        }
        public BlackStorkContext(string connectionString) : base(connectionString) { }
    }
}
