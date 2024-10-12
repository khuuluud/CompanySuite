using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace LinkDev.CompanyBase.PL.ViewModels.Departments
{
    public class DepartmentEditViewModel
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
