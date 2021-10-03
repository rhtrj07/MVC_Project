using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.3.1.min.js", "~/Scripts/umd/jquery-3.3.1.js", "~/Scripts/umd/popper.min.js", "~/Scripts/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/custom/bootstrap").Include("~/Scripts/custom/jquery.mCustomScrollbar.concat.min.js", "~/Scripts/custom/main.js", "~/Scripts/custom/icon.js", "~/Scripts/custom/js/bootstrap-admin.js"));
            bundles.Add(new StyleBundle("~/Styles/custom/bootstrap").Include("~/Scripts/custom/all.css", "~/Scripts/custom/jquery.mCustomScrollbar.min.css", "~/Scripts/custom/css/sidebar-themes.css", "~/Scripts/custom/css/main.css", "~/Scripts/custom/css/bootstrap-admin.css"));


           BundleTable.EnableOptimizations = true;

        }
    }
}