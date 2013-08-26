using System.Configuration;
using Groupr.Core.Data;
using Groupr.Core.Repositories;
using Groupr.Core.Repositories.Common;
using Microsoft.Practices.ServiceLocation;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using StructureMap;

namespace Groupr.Core.Infrastructure
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            ConfigureIocContainer();
            ConfigureConnectionFactory();

            LogManager.LogFactory = new Log4NetFactory(true);
        }

        private static void ConfigureIocContainer()
        {
            var container = new Container();

            container.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            scan.TheCallingAssembly();

                            scan.AssembliesFromApplicationBaseDirectory(
                                assembly =>
                                assembly
                                    .GetName()
                                    .Name
                                    .StartsWith("Groupr."));

                            scan.WithDefaultConventions();
                            scan.LookForRegistries();
                        });

                    config.For<IMemberRepository>().Use<MemberRepository>();
                    config.For<ILocationRepository>().Use<LocationRepository>();
                    config.For<IMeetingRepository>().Use<MeetingRepository>();
                    config.For<IMessageRepository>().Use <MessageRepository>();
                });

            ServiceLocator.SetLocatorProvider(
                () => new StructureMapServiceLocator(container));
        }

        private static void ConfigureConnectionFactory()
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings["Groupr"];

            if (connectionString == null)
            {
                throw new ConfigurationErrorsException(
                    "Connection string with name 'Groupr' is not configured.");
            }

            Database.Factory =
                new OrmLiteConnectionFactory(
                    connectionString.ConnectionString,
                    SqlServerOrmLiteDialectProvider.Instance);
        }
    }
}