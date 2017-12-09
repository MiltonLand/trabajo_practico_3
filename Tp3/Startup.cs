using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tp3.Startup))]
namespace Tp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
