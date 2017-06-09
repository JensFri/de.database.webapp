using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_CustomerSuchenDB.Startup))]
namespace mvc_CustomerSuchenDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
