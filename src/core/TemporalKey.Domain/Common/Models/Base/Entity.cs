using TemporalKey.Domain.Common.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Models
{
    public abstract class Entity<TId>:IEquatable<TId>, IEntity<TId>
        where TId : notnull 
    {

       
        public TId Id { get;  }
        #pragma warning disable CS8618
        protected Entity()
        {
           
        }
        protected Entity(TId id)
        {
            Id = id;
        }
        #pragma warning restore CS8618
        public override bool Equals(object? obj)
        {
            if (obj is null && Id is null)
            {
                return true;
            }            
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(TId? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }
        public override int GetHashCode()
        {
            if (Id is null)
            {
                return 0;
            }
            return Id.GetHashCode();
        }

       
    }
}
