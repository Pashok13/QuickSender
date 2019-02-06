using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessengeSending.Models
{
	public class Phone
	{
		[Key]
		public int Id			{ get; set; }
		public string Number	{ get; set; }

		public ICollection<MessegeRecipient> MessageRecipient	{ get; set; }
		public ICollection<AdditInfo> AdditInfo					{ get; set; }

		public Phone()
		{
			MessageRecipient = new List<MessegeRecipient>();
			AdditInfo = new List<AdditInfo>();
		}
	}
}