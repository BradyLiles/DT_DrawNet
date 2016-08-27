using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrawNet.Web.Draw.Startup))]
namespace DrawNet.Web.Draw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
