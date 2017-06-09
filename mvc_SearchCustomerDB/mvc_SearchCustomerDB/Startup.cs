using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_SearchCustomerDB.Startup))]
namespace mvc_SearchCustomerDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
