using System.Web;
using System.Web.Optimization;

namespace OA_Game.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/knockout-3.2.0.js",
                         "~/Scripts/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //HOME
            bundles.Add(new StyleBundle("~/Content/Home").Include(
                      "~/Content/tinycarousel.css",
                      "~/Content/jquery-rebox.css",
                      "~/Content/animate.css"));
            //Home
            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                   "~/Scripts/jquery.tinycarousel.js",
                    "~/Scripts/jquery-rebox.js",
                   "~/Scripts/js/Home.js"));

            //Admin
            bundles.Add(new ScriptBundle("~/bundles/Admin").Include(               
                   "~/Scripts/js/Admin.js"));
            //konckout
            bundles.Add(new ScriptBundle("~/bundles/konckout").Include(
                 "~/Scripts/knockout-3.2.0.js", "~/Scripts/knockout.mapping-latest.js"));

            //moment
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                 "~/Scripts/moment.js"));
            //Mobile
            bundles.Add(new ScriptBundle("~/bundles/Mobile").Include(
                 "~/Scripts/swiper.js",
                 "~/Scripts/js/Mobile.js"));
            //Mobile
            bundles.Add(new StyleBundle("~/Content/Mobile").Include(
                     "~/Content/swiper.css",
                     "~/Content/animate.css"));
            //Contact
            bundles.Add(new ScriptBundle("~/bundles/Contact").Include(              
               "~/Scripts/js/Contact.js"));
        }
    }
}
