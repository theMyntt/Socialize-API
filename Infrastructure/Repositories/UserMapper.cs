using System;
using Socialize.Core;
using Socialize.Domain.Aggregates;
using Socialize.Models;

namespace Socialize.Infrastructure.Repositories
{
    public class UserMapper : IMapperService<UserAggregate, User>
    {
        public UserAggregate toDomain(User target)
        {
            return new UserAggregate(target.Id, target.Name, target.Code, target.Email, target.Password, target.Description, target.Photo, target.CreatedAt); 
        }

        public User toPersistance(UserAggregate schema)
        {
            return new User(schema.Id ?? 1, schema.Name, schema.Code, schema.Email, schema.Password, schema.Description, schema.Photo, schema.CreatedAt);
        }
    }
}

