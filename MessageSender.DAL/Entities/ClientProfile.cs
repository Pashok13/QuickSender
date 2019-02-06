using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageSender.DAL.Entities
{
	public class ClientProfile
	{
		[Key]
		[ForeignKey("ApplicationUser")]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
