using System.Web.Optimization;

// ReSharper disable CheckNamespace
namespace Groupr.Web
// ReSharper restore CheckNamespace
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundle(bundles);
            RegisterScriptBundle(bundles);
        }

        private static void RegisterStyleBundle(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/Content/css")
                    .Include(
                        "~/Content/font-awesome.css",
                        "~/Content/foundation/stylesheets/app.css",
                        "~/Content/foundation/stylesheets/styles.css",
                        "~/Content/groupr.forms.css"));
        }

        private static void RegisterScriptBundle(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/modernizr")
                    .Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/jquery")
                    .Include(
                        "~/Content/foundation/javascripts/vendor/jquery.js"));
                        //"~/Scripts/jquery-{version}.js",
                        //"~/Scripts/jquery-migrate-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/validation")
                    .Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(
                new ScriptBundle("~/bundles/foundation")
                    .Include(
                        "~/Content/foundation/javascripts/foundation/foundation.js",
                        "~/Content/foundation/javascripts/foundation/foundation.*"));

            bundles.Add(
                new ScriptBundle("~/bundles/groupr")
                    .Include(
                        "~/Scripts/groupr.js",
                        "~/Scripts/groupr.*"));
        }
    }
}