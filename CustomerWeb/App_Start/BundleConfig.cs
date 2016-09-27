using System.Web;
using System.Web.Optimization;

namespace CustomerWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib")
                .Include(
                "~/Scripts/lib/jquery-{version}.js",
                "~/Scripts/lib/jquery.validate*",
                "~/Scripts/lib/modernizr-*",
                "~/Scripts/lib/bootstrap.js",
                "~/Scripts/lib/respond.js",
                "~/Scripts/lib/knockout-3.4.0.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include(
                "~/Scripts/App/mainViewModel.js",
                "~/Scripts/App/customer.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
