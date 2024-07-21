using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socialize.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Code { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public string? Description { get; set; }
		public required string Photo { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}

