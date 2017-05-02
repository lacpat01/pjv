using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(groupePjvApp.Startup))]
namespace groupePjvApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
