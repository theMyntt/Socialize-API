using System;
namespace Socialize.Core
{
	public interface IMapperService<Aggregate, Entity>
	{
		Aggregate toDomain(Entity target);
		Entity toPersistance(Aggregate schema);
	}
}

