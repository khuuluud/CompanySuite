using LinkDev.CompanyBase.DAL.Common.Enum;
using LinkDev.CompanyBase.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Moduls.DTO.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        [DataType(DataType.Currency)]

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;

        public string Department { get; set; }
    }
    }
