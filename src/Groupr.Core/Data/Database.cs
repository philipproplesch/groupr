using ServiceStack.OrmLite;

namespace Groupr.Core.Data
{
	public class Database
	{
		public static OrmLiteConnectionFactory Factory
		{
			get; 
			internal set;
		}
	}
}