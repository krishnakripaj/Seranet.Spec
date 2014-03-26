using System.Web;
using System.Web.Optimization;

namespace Seranet.SpecM2.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-sanitize.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/spin").Include(
                        "~/Scripts/spin.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui-bootstrap").Include(
                        "~/Scripts/ui-bootstrap-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/app/app.js",
                        "~/app/config.js",
                        "~/app/config.exceptionHandler.js",
                        "~/app/config.route.js",

                        "~/app/common/common.js",
                        "~/app/common/logger.js",
                        "~/app/common/spinner.js",
                        
                        "~/app/common/bootstrap/bootstrap.dialog.js",

                        "~/app/admin/admin.js",
                        "~/app/dashboard/dashboard.js",
                        "~/app/project/project.js",
                        "~/app/activities/activities.js",

                        "~/app/layout/shell.js",
                        "~/app/layout/sidebar.js",
                        "~/app/layout/topnav.js",
                        "~/app/services/datacontext.js",
                        "~/app/services/directives.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/site-base/js/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/default-theme/css/main.css",
                      "~/Content/site-base/css/bootstrap.css",
                      "~/Content/site-base/css/toastr.min.css"));
        }
    }
}
