using System;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    /// <summary>
    /// The class for introduction of dependencies
    /// </summary>
    public class ServiceModule: NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        /// <summary>
        /// The method establishes dependecies.
        /// The EFUnitOfWorh use as the object IUnitOfWork
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
