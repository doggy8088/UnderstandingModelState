using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnderstandingModelState.Startup))]
namespace UnderstandingModelState
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
