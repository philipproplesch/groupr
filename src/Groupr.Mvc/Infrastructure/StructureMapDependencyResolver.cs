using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;

namespace Groupr.Mvc.Infrastructure
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return !serviceType.IsAbstract
                       ? ServiceLocator.Current.GetService(serviceType)
                       : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ServiceLocator.Current.GetAllInstances(serviceType);
        }
    }
}