using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMDb_Applicatie.Startup))]
namespace IMDb_Applicatie
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
