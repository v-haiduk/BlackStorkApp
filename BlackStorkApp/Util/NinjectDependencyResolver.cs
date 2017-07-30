using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using BLL.Services;
using BLL.Interfaces;
using System.Web.Mvc;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;


namespace BlackStorkApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IMainService<TopicDTO>>().To<TopicService>();
            kernel.Bind<IMainService<ProductDTO>>().To<ProductService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IMainService<EmailSendingDTO>>().To<EmailSendingService>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}