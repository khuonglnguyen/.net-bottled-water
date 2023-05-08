using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopNuocOnline.Startup))]
namespace ShopNuocOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
