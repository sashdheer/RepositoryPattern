using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepositoryPattern.Startup))]
namespace RepositoryPattern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
