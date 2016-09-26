using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Voorbeeld3.Startup))]
namespace MVC_Voorbeeld3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
