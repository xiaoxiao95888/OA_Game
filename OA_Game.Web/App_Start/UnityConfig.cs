using Microsoft.Practices.Unity;
using System.Web.Http;
using OA_Game.Library.Services;
using OA_Game.Service.Services;
using Unity.WebApi;

namespace OA_Game.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRequiredService, RequiredService>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IPvService, PvService>();

            container.RegisterType<IArticleCategoryService, ArticleCategoryService>();
            container.RegisterType<IAdminUserService, AdminUserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}