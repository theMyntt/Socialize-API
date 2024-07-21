using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socialize.Models
{
	public class Publication
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public required string Text { get; set; }
		public required User CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}

