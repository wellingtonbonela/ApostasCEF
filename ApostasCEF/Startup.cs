using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApostasCEF.Startup))]
namespace ApostasCEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
