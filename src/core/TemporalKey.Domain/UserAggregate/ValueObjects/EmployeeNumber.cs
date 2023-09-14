using TemporalKey.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Models.Base;

namespace TemporalKey.Domain.UserDataAggregate.ValueObjects
{
    public class EmployeeNumber : OrdinaryValueObject
    {
        private EmployeeNumber() : base()
        {

        }
        private EmployeeNumber(Guid value) : base(value)
        {

        }
        private EmployeeNumber(OrdinaryValueObject ordinaryValueObject) : base(ordinaryValueObject) { }
        public static EmployeeNumber CreateUnique()
        {
            return new(CreateUniqueBase());
        }

    }
}
