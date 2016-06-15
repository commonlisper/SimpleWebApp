using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SimpleWebApp.CMS
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/scripts/knockout-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/requirejs").Include(
                "~/scripts/require.js"));
        }
    }
}