using LinkDev.CompanyBase.DAL.Models.Departments;
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
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

        Task<DepartmentDetailsDto> GetDepByIdAsync(int id);

        Task<int> CreateDepartmentAsync(CreatedDepartmentDto department);

        Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto department);

        Task<bool> DeleteDepartmentAsync(int id);
    }
}
