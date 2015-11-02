using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MediaLibrary.Startup))]

namespace MediaLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
