using System.Web.Mvc;
using Groupr.Mvc.Filters;

namespace Groupr.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		    filters.Add(new InitializeSimpleMembershipAttribute());
		}
	}
}