using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aplicacion.Startup))]
namespace Aplicacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
