using LinkDev.CompanySuite.DAL.Common.Enum;
using LinkDev.CompanySuite.DAL.Models .Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Data.Configuration.Employees
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.Gender)
                   .HasConversion(
                   (gender) => gender.ToString(),
                   (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                   );

            builder.Property(E => E.EmployeeType)
               .HasConversion(
               (type) => type.ToString(),
               (type) => (EmpType)Enum.Parse(typeof(EmpType), type)
               );
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql(" GETDATE()");
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
       