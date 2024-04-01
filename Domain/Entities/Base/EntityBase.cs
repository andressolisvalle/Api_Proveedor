using Domain.Entities.Base.Interface;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class EntityBase<T> : DomainEntity, IEntityBase<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual T Id { get; set; } = default!;
    }
}
