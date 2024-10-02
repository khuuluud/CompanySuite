using LinkDev.CompanySuite.DAL.Models .Department;
using LinkDev.CompanySutie.BLL.Moduls.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySutie.BLL.Services.Departments
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
