using System.Text;
using System.Web;
using System.Web.Mvc;
using Groupr.Core.Extensions;
using Groupr.Mvc.ViewModels;

namespace Groupr.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Gravatar(
            this HtmlHelper instance,
            string mailAddress,
            int size = 200)
        {
            var builder = new TagBuilder("img");
            builder.Attributes["src"] =
                string.Format(
                    "http://www.gravatar.com/avatar/{0}.jpg?s={1}",
                    mailAddress.MD5(),
                    size);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static string MapUrl(this HtmlHelper instance, LocationViewModel location)
        {
            var address =
                HttpUtility.UrlEncode(
                    string.Concat(
                        location.Name,
                        ", ",
                        location.Street, ", ",
                        location.City));

            return string.Concat("http://maps.google.com/maps?daddr=", address);
        }
    }
}