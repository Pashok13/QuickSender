using MessageSender.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengeSending.Models
{

	public class Message
	{
        [Key] 
        public int MessageId		{ get; set; }
		public string UserId			{ get; set; }
		public string TextMessage   { get; set; }

        [ForeignKey("UserId")]
		public ClientProfile User			{ get; set; }

		public ICollection<MessegeRecipient> MessageRecipient { get; set; }

		public Message()
		{
			MessageRecipient = new List<MessegeRecipient>();
		}
	}
}
