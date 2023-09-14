using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.UserAggregate.ValueObjects;
using TemporalKey.Domain.UserAggregate;

namespace TemporalKey.Infastracture.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
            ConfigurationUserDataTable(builder);
        }


        private void ConfigurationUserDataTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(m => m.UserData, ud =>
            {

                ud.ToTable("UserData");
                 
                ud.WithOwner().HasForeignKey("UserId");
                ud.OwnsOne(x => x.Id, ownedBuilder => {
                    ownedBuilder.Property(m => m.Value).HasColumnName("Id_Value");
                    ownedBuilder.Property(m => m.SnapShotDate).HasColumnName("Id_SnapShotDate");
                });
                builder.Property(typeof(Guid), "Id_value").HasColumnName("Id_Value");
                builder.Property(typeof(DateTime), "Id_SnapShotDate").HasColumnName("Id_SnapShotDate");
                builder.HasKey("Id_value", "Id_SnapShotDate");


                ud.Property(m => m.FirstName).HasMaxLength(255);
                ud.Property(m => m.MiddleName).HasMaxLength(255);
                ud.Property(m => m.LastName).HasMaxLength(255);

                ud.OwnsOne(m => m.Email);
                ud.OwnsOne(m => m.Phone);
                ud.OwnsOne(m => m.EmployeeNumber);

            });
            builder.Metadata.FindNavigation(nameof(User.UserData))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
           
            builder.OwnsOne(x => x.Id, ownedBuilder => {
                ownedBuilder.Property(x => x.Value).HasColumnName("Id_Value");
            });
            builder.Property(typeof(Guid), "Id_Value").HasColumnName("Id_Value");
            builder.HasKey("Id_Value");

            builder.Property(m => m.UserName).HasMaxLength(255);
            builder.Property(m => m.Password).HasMaxLength(50);
            builder.Ignore(m => m.CurrentActualData);
        }
    }
}
