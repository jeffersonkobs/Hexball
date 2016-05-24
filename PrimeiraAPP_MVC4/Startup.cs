using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeiraAPP_MVC4.Startup))]
namespace PrimeiraAPP_MVC4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
