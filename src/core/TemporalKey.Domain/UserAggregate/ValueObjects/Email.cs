using TemporalKey.Domain.Common.Models;
using TemporalKey.Domain.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace TemporalKey.Domain.UserDataAggregate.ValueObjects
{
    public class Email : OrdinaryValueObject
    {

        public string WorkEmail { get; private set; } = string.Empty;
        public string HomeEmail { get; private set; } = string.Empty;
        private Email() : base()
        {

        }
        private Email(string workEmail, string homeEmail = "")
        {
            WorkEmail = workEmail;
            HomeEmail = homeEmail;
        }

        public static Email CreateEmail(string workEmail, string homeEmail = "")
        {
            return new(workEmail, homeEmail);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return WorkEmail;
            yield return HomeEmail;
        }
    }
}
