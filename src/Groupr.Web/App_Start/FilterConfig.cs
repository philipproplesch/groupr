using System.Web.Mvc;
using Groupr.Mvc.Filters;

// ReSharper disable CheckNamespace
namespace Groupr.Web
// ReSharper restore CheckNamespace
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