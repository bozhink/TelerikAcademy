using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudentSystem.Startup))]

namespace StudentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}