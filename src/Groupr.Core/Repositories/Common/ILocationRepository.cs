using System.Collections.Generic;
using Groupr.Core.Models;

namespace Groupr.Core.Repositories.Common
{
	public interface ILocationRepository
	{
        Location GetLocationById(int id);
	    List<Location> GetLocations();
	    bool CreateLocation(Location location);
	}
}