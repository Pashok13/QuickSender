using Microsoft.AspNet.Identity.EntityFramework;

namespace MessageSender.DAL.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public virtual ClientProfile ClientProfile { get; set; }
	}
}
