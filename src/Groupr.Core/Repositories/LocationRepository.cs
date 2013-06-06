using System.Collections.Generic;
using Groupr.Core.Data;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using ServiceStack.OrmLite;

namespace Groupr.Core.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public Location GetLocationById(int id)
        {
            using (var connection = Database.Factory.Open())
            {
                return connection.QueryById<Location>(id);
            }
        }

        public List<Location> GetLocations()
        {
            using (var connection = Database.Factory.Open())
            {
                return connection.Select<Location>();
            }
        }

        public bool CreateLocation(Location location)
        {
            using (var connection = Database.Factory.Open())
            {
                connection.Insert(location);
                return connection.GetLastInsertId() > 0;
            }
        }
    }
}