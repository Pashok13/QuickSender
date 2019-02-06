using System.ComponentModel.DataAnnotations;

namespace MessageSender.Models
{
	public class LoginModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

	}
}