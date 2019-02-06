using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessengeSending.Models
{
	public class MessegeRecipient
	{
		[Key]
		public int Id				{ get; set; }
		public int MessageId		{ get; set; }
		public int RecepientId		{ get; set; }
		public DateTime CreateDate	{ get; set; }
		public DateTime StartDate	{ get; set; }
		public DateTime EndDate		{ get; set; }
		public DateTime Period		{ get; set; }

		[ForeignKey("MessageId")]
		public Message Message		{ get; set; }

		[ForeignKey("RecepientId")]
		public Phone Phone			{ get; set; }
	}
}