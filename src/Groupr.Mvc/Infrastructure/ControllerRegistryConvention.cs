using System;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Groupr.Mvc.Infrastructure
{
    public class ControllerRegistryConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsAbstract && typeof(IController).IsAssignableFrom(type))
            {
                registry.AddType(type, type);
            }
        }
    }
}
