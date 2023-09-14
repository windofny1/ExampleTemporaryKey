using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Models.Base;

namespace TemporalKey.Domain.UserAggregate.ValueObjects
{
    public class UserId : OrdinaryValueObject
    {

        private UserId(Guid value) : base(value)
        {

        }

        private UserId(OrdinaryValueObject ordinaryValueObject) : base(ordinaryValueObject) { }
        public static UserId CreateUnique()
        {
            return new(CreateUniqueBase());
        }

    }
}
