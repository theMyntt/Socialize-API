using System;
using System.ComponentModel.DataAnnotations;

namespace Socialize.DTOs
{
	public class NewUserDTO
	{
		[Required]
		public required string Name { get; set; }

		[Required]
		public required string Code { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
		public string? Description { get; set; }

        [Required]
        public required IFormFile Photo { get; set; }
	}

	public class LoginUserDTO
	{
		[Required]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }
	}

    public class UserUpdateDto
    {
		[Required]
        public required string Name { get; set; }

		[Required]
        public required string Email { get; set; }

        public string? Description { get; set; }

		[Required]
        public required IFormFile Photo { get; set; }
    }

	public class DeleteUserDTO
	{
		[Required]
		public required string Password { get; set; }
	}
}

