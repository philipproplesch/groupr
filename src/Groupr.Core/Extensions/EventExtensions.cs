using System.Text;
using Groupr.Core.Models;

namespace Groupr.Core.Extensions
{
    public static class EventExtensions
    {
        public static string ToIcs(this Meeting instance)
        {
            var builder = new StringBuilder();

            builder.AppendLine("BEGIN:VCALENDAR");
            builder.AppendLine("VERSION:2.0");
            builder.AppendLine("PRODID:-//hacksw/handcal//NONSGML v1.0//EN");
            builder.AppendLine("BEGIN:VEVENT");

            builder.AppendFormat(
                "DTSTART: {0}\r\n",
                instance.StartDate.ToUniversalTime().ToString("yyyyMMddTHHmmssZ"));

            builder.AppendFormat(
                "DTEND: {0}\r\n",
                instance.EndDate.ToUniversalTime().ToString("yyyyMMddTHHmmssZ"));

            builder.AppendFormat(
                "SUMMARY: {0}\r\n", 
                instance.Name);

            builder.AppendFormat(
                "LOCATION: {0}\r\n",
                instance.LocationId);

            builder.AppendLine("END:VEVENT");
            builder.AppendLine("END:VCALENDAR");

            return builder.ToString();
        }
    }
}