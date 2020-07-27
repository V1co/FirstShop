using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstShop.WebUI.Startup))]
namespace FirstShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
