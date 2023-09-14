using TemporalKey.Domain.Common.Models;
using TemporalKey.Domain.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.UserDataAggregate.ValueObjects
{
    public class Phone : ValueObject
    {
        private Phone() : base() { }
        public string CityPhoneNumber { get; private set; } = string.Empty;
        public string? MobilePhoneNumber { get; private set; } = null;


        public string? InnerPhoneNumber { get; private set; } = null;

        private Phone(string cityPhoneNumber, string mobilePhoneNumber = "", string innerPhoneNumber = "")
        {
            CityPhoneNumber = cityPhoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
            InnerPhoneNumber = innerPhoneNumber;
        }

        public static Phone CreatePhone(string cityPhoneNumber, string mobilePhoneNumber = "", string innerPhoneNumber = "")
        {
            return new(cityPhoneNumber, mobilePhoneNumber, innerPhoneNumber);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return CityPhoneNumber;
            yield return MobilePhoneNumber ?? "";
            yield return InnerPhoneNumber ?? "";
        }
    }
}
