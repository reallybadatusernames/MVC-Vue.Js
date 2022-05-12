using System.Web;
using System.Web.Optimization;

namespace mvc.vuejs.example
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/client/libs/jquery/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/client/libs/jquery/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/client/libs/modernizr/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/client/libs/bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/client/libs/bootstrap/css/bootstrap.css",
                      "~/client/site.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                    "~/client/libs/jquery/js/jquery-{version}.js",
                    "~/client/libs/vue/js/vue.js"));
        }
    }
}
