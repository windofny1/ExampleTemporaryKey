using TemporalKey.Domain.Common.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Models
{
    public abstract class ValueObject:IEquatable<ValueObject>, IValueObject
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        protected ValueObject()
        {

        }
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType()) return false;
            var valueObj = obj as ValueObject;
            return GetEqualityComponents().
                SequenceEqual(valueObj!.GetEqualityComponents());
        }
        public static bool operator ==(ValueObject left, ValueObject right) {  return Equals(left,right); }
        public static bool operator !=(ValueObject left, ValueObject right) { return !Equals(left, right); }
        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(m=>m?.GetHashCode() ?? 0).
                Aggregate((x,y)=>x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}
