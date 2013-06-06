using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Groupr.Mvc.Infrastructure
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            ObjectFactory.Configure(
                container =>
                container.Scan(
                    scan =>
                        {
                            scan.AddAllTypesOf<IController>();
                            scan.With(new ControllerRegistryConvention());
                        }));

            DependencyResolver.SetResolver(
                new StructureMapDependencyResolver());
        }
    }
}