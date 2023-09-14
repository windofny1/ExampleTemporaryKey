using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Models.Base;
using TemporalKey.Domain.UserAggregate.Entities;
using TemporalKey.Domain.UserAggregate.ValueObjects;

namespace TemporalKey.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {

        private User() : base(UserId.CreateUnique())
        {



        }

        public string UserName { get; private set; } = "";
        public string Password { get; private set; } = "";

        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? BlockedAt { get; private set; } = null;

        private readonly List<UserData> _userData = new();
        public IReadOnlyList<UserData> UserData => _userData.OrderByDescending(m => m.Id.SnapShotDate).ToList().AsReadOnly();
        public UserData? CurrentActualData => UserData.FirstOrDefault();

        private User(UserId userId, string userName, string password, List<UserData> userData, DateTime createdDate,
            DateTime? updatedDate = null, DateTime? blockedAt = null) : base(userId ?? UserId.CreateUnique())
        {
            UserName = userName;
            Password = password;
            BlockedAt = blockedAt;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            _userData = new List<UserData>(userData);
        }
        public static User Create(string userName, string password, List<UserData> userData, DateTime createdDate, DateTime? updatedDate = null, DateTime? blockedAt = null)
        {
            return new(UserId.CreateUnique(), userName, password, userData, createdDate, updatedDate, blockedAt);
        }
    }
}
