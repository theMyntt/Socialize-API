using System;
using System.ComponentModel.DataAnnotations;

namespace Socialize.DTOs
{
	public class LikesDTO
	{
		[Required]
		public int PublicationId { get; set; }

		[Required]
		public required string UserCode { get; set; }
	}
}

