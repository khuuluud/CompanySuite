using LinkDev.CompanySuite.DAL.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Models.Employees
{
    public class Employee : ModelBase
    {

        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
    }
}
