using LinkDev.CompanyBase.DAL.Common.Enum;
using LinkDev.CompanyBase.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Models.Employees
{
    public class Employee : ModelBase
    {

        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }

        //Foriegn key
        public int? DepartmentId { get; set; }

        // Navigational Property  [One]
        public virtual Department? Department { get; set; }

        public string? Img { get; set; }
    }
}
