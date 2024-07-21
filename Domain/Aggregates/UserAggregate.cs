using System;
namespace Socialize.Domain.Aggregates
{
	public class UserAggregate
	{
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserAggregate(
            int? id,
            string name,
            string code,
            string email,
            string password,
            string? description,
            string photo,
            DateTime? createdAt
        ) {
            Id = id;
            Code = code;
            Email = email;
            Name = name;
            Password = password;
            Description = description;
            Photo = photo;
            CreatedAt = createdAt ?? DateTime.Now;
        }
    }
}

