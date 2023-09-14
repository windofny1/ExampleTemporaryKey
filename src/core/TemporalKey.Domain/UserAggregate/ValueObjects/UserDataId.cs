using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Models.Base;

namespace TemporalKey.Domain.UserAggregate.ValueObjects
{
    public class UserDataId : TemporalValueObject
    {
        private UserDataId() : base() { }
        private UserDataId(Guid value, DateTime snapShotDate) : base(value, snapShotDate)
        {

        }
        private UserDataId(TemporalValueObject temporalValueObject) : base(temporalValueObject) { }
        public static UserDataId CreateUnique()
        {
            return new(CreateUniqueBase());
        }

    }
}
