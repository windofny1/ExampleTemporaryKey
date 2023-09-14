using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Models.Base
{
    public class OrdinaryValueObject : ValueObject
    {
        public Guid Value { get; protected set; }
        protected OrdinaryValueObject() : base()
        {

        }
        protected OrdinaryValueObject(Guid value)
        {
            Value = value;
        }
        protected OrdinaryValueObject(OrdinaryValueObject ordinaryValueObject)
        {
            Value = ordinaryValueObject.Value;
        }
        protected static OrdinaryValueObject CreateUniqueBase()
        {
            return (new OrdinaryValueObject(Guid.NewGuid()));
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
