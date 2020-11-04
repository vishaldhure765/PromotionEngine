using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PromotionApp.Startup))]
namespace PromotionApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
