using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Models.Base
{
    public abstract class AggregateRootId<TId>:ValueObject
    {
        public abstract TId Value { get;protected set; }
        protected AggregateRootId()
        {

        }
        protected AggregateRootId(TId value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }
        public override int GetHashCode()
        {
            return Value!.GetHashCode();
        }
    }
}
