using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Models;
using TemporalKey.Domain.Common.Models.Base;
using TemporalKey.Domain.UserAggregate.ValueObjects;
using TemporalKey.Domain.UserDataAggregate.ValueObjects;
using static TemporalKey.Domain.UserDataAggregate.Enums.WorkingHours;

namespace TemporalKey.Domain.UserAggregate.Entities
{
    public class UserData : Entity<UserDataId>
    {
        private UserData() : base()
        {

        }
        private UserData(UserDataId userDataId,
           string firstName, string middleName, string lastName, Email email, Phone phone,
           WorkingHoursEnum workingHours = WorkingHoursEnum.Normal, bool preventUpdate = false, DateTime? firedAt = null, DateTime? updatedDate = null,
           EmployeeNumber? employeeNumber = null, DateTime? dateOfBirth = null) :
           base(userDataId ?? UserDataId.CreateUnique())
        {
            PreventUpdate = preventUpdate;
            FiredAt = firedAt;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            WorkingHours = workingHours;           
            EmployeeNumber = employeeNumber;
            DateOfBirth = dateOfBirth;
            UpdatedDate = updatedDate;
        }

        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }

        public bool PreventUpdate { get; private set; }
        public DateTime? FiredAt { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        

 
        public EmployeeNumber? EmployeeNumber { get; private set; } = null;

        public DateTime? DateOfBirth { get; private set; } = null;
        public WorkingHoursEnum WorkingHours { get; set; } = WorkingHoursEnum.Normal;


        public static UserData Create(
            string firstName, string middleName, string lastName, Email email, Phone phone,
            WorkingHoursEnum workingHours = WorkingHoursEnum.Normal, bool preventUpdate = false, DateTime? firedAt = null, DateTime? updatedDate = null,
             EmployeeNumber? employeeNumber = null,
            DateTime? dateOfBirth = null)
        {
            return new(UserDataId.CreateUnique(), firstName, middleName, lastName,
                email, phone, workingHours, preventUpdate, firedAt, updatedDate,  employeeNumber, dateOfBirth);
        }


    }
}
