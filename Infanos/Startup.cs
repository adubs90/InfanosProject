using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Infanos.Startup))]
namespace Infanos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
