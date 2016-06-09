using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BedRockBankUI.Startup))]
namespace BedRockBankUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
