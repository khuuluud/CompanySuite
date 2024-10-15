using LinkDev.CompanyBase.DAL.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.CompanyBase.PL.ViewModels.Employees
{
    public class EmployeeViewmodel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length of name is 50 charachters")]
        [MinLength(5, ErrorMessage = "Max length of name is 5 charachters")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
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

        [Display(Name ="Department")]
        public int? DepartmentId { get; set; }

        public string? Department { get; set; }

    }
}
