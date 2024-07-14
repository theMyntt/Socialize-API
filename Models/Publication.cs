using System;
namespace Socialize.Models
{
	public class Publication
	{
		public int Id { get; set; }
		public required string Text { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}

