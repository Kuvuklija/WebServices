﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WebServices.Models;

namespace WebServices.Infrastructure{

    public class NinjectDependencyResolver : IDependencyResolver{

        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType){
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType){
            return kernel.GetAll(serviceType);
        }

        public void AddBindings() {
            kernel.Bind<IRepository>().To<MarksRepository>();
        }
    }
}