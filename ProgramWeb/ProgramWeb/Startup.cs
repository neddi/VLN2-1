using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramWeb.Startup))]
namespace ProgramWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			app.MapSignalR();
        }
    }
}
