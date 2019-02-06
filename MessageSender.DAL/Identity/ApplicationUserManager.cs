using MessageSender.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace MessageSender.DAL.Identity
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store)
				: base(store)
		{
		}
	}
}
