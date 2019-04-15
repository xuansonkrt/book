using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(book.Startup))]
namespace book
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
