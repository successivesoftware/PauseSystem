using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PauseSystem.Startup))]
namespace PauseSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
