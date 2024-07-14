using System;
using System.ComponentModel.DataAnnotations;

namespace Socialize.DTOs
{
	public class NewPublicationDTO
	{
		[Required]
		public required string Text { get; set; }
	}
}

