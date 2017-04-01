using Microsoft.Owin;
using Owin;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
