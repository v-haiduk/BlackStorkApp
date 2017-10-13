using System.Web;
using System.Web.Optimization;

namespace BlackStorkApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/AdminStyle").Include(
                "~/Content/bootstrap.min.css", 
                "~/Content/animate.min.css", 
                "~/Content/custom.css", 
                "~/Content/maps/jquery-jvectormap-2.0.3.css",
                "~/Content/icheck/flat/green.css",
                "~/Content//floatexamples.css",
                "~/Content/Site.css") );

            bundles.Add(new ScriptBundle("~/Scripts/AdminScript").Include(
                "~/Scripts/icheck/icheck.min.js",
                "~/Scripts/jquery.min.js",
                "~/Scripts/nprogress.js",
                "~/Scripts/jquery-1.10.2.js", 
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new StyleBundle("~/Content/MainStyle").Include(
                "~/Content/main/main.css",
                "~/Content/main/default-domainless.css",
                "~/Content/main/black-stork.css",
                "~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/MainScript").Include(
                "~/Scripts/main/jquery.js",
                "~/Scripts/main/functions.js"));
        }
    }
}
