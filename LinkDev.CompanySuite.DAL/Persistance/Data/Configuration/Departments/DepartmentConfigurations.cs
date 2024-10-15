using LinkDev.CompanyBase.DAL.Models .Departments;
using LinkDev.CompanyBase.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Persistance.Data.Configuration.Departments
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(D => D.Code).HasColumnType("varchar(20)").HasMaxLength(50).IsRequired();
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql(" GETDATE()");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.HasMany(D => D.Employees)
                   .WithOne(E => E.Department)
                   .HasForeignKey(E => E.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);
        
        
        
        
        }
    }
}
