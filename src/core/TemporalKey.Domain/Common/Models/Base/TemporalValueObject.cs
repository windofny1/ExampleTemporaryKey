using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Models.Base
{
    public class TemporalValueObject : OrdinaryValueObject
    {
        public DateTime SnapShotDate { get; protected set; }

        protected TemporalValueObject() : base() { }
        protected TemporalValueObject(Guid value, DateTime snapShotDate) : base(value)
        {
            SnapShotDate = snapShotDate;
        }
        protected TemporalValueObject(TemporalValueObject temporalValueObject) : base(temporalValueObject.Value)
        {
            SnapShotDate = temporalValueObject.SnapShotDate;
        }
        protected static TemporalValueObject CreateUniqueBase()
        {
            return new TemporalValueObject(Guid.NewGuid(), DateTime.UtcNow);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return SnapShotDate;
        }
    }
}
