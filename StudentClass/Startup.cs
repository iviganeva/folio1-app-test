using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentClass.Startup))]
namespace StudentClass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
