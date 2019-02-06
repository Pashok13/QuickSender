using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using MessageSender.BLL.Services;
using Microsoft.AspNet.Identity;
using MessageSender.BLL.Interfaces;

[assembly: OwinStartup(typeof(MessageSender.App_Start.Startup))]

namespace MessageSender.App_Start
{
	public class Startup
	{
		IServiceCreator serviceCreator = new ServiceCreator();
		public void Configuration(IAppBuilder app)
		{
			app.CreatePerOwinContext<IUserService>(CreateUserService);
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
			});
		}

		private IUserService CreateUserService()
		{
			return serviceCreator.CreateUserService("DefaultConnection");
		}
	}
}