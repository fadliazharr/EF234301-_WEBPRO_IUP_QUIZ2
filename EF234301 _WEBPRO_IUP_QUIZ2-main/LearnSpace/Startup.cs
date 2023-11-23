using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnSpace.Startup))]
namespace LearnSpace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
