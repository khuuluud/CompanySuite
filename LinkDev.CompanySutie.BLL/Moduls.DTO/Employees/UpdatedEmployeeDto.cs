using LinkDev.CompanyBase.DAL.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Moduls.DTO.Employees
{
    public class UpdatedEmployeeDto
    {

        public int Id { get; set; }
        
        [MaxLength(50, ErrorMessage = "Max length of name is 50 charachters")]
        [MinLength(5, ErrorMessage = "Max length of name is 5 charachters")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5-10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
                            , ErrorMessage = "Address must be like 123-street-City-Country")]
        public string? Address { get; set; }

        public decimal Salary { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }


        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring date")]
        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }


    }
}
