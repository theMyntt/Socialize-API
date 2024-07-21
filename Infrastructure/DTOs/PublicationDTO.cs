using System;
using System.ComponentModel.DataAnnotations;

namespace Socialize.DTOs
{
	public class NewPublicationDTO
	{
		[Required]
		public required string Text { get; set; }

		[Required]
		public required string UserCode { get; set; }
	}
}

