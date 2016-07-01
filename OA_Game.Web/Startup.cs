using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OA_Game.Web.Startup))]
namespace OA_Game.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
