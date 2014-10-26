using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ass1.Startup))]
namespace Ass1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
