using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetShip.Startup))]
namespace GetShip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    
    }
}
