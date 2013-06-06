﻿using System.Web.Optimization;

namespace Groupr.Web
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
                        "~/Content/groupr.forms.css",
                        "~/Content/groupr.compability.css"));
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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/validation")
                    .Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(
                new ScriptBundle("~/bundles/foundation")
                    .Include(
                        //"~/Content/foundation/javascripts/foundation/modernizr.foundation.js",
                        "~/Content/foundation/javascripts/foundation/jquery.foundation*",
                        "~/Content/foundation/javascripts/foundation/app.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/groupr")
                    .Include(
                        "~/Scripts/groupr.js",
                        "~/Scripts/groupr.*"));
        }
    }
}