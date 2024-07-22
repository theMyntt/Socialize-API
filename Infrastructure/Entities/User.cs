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
		public string Name { get; set; }
		public string Code { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? Description { get; set; }
		public string Photo { get; set; }
		public DateTime CreatedAt { get; set; }

        public User(
            int id,
            string name,
            string code,
            string email,
            string password,
            string? description,
            string photo,
            DateTime createdAt)
        {
            Id = id;
            Name = name;
            Code = code;
            Email = email;
            Password = password;
            Description = description;
            Photo = photo;
            CreatedAt = createdAt;
        }
    }
}

