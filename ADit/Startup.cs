using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADit.Startup))]
namespace ADit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
