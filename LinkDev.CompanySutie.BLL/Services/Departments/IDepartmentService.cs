using LinkDev.CompanyBase.DAL.Models.Department;
using LinkDev.CompanyBase.BLL.Moduls.DTO.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetAllDepartments();

        DepartmentDetailsDto GetDepById(int id);

        int CreateDepartment(CreatedDepartmentDto department);

        int UpdateDepartment(UpdatedDepartmentDto department);

        bool DeleteDepartment(int id);
    }
}
