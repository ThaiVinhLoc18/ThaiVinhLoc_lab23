using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBook_lab23.Startup))]
namespace WebBook_lab23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
