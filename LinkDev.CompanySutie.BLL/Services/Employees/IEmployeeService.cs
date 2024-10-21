using LinkDev.CompanyBase.BLL.Moduls.DTO.Departments;
using LinkDev.CompanyBase.BLL.Moduls.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(string search);

        Task<EmployeeDetailsDto> GetEmpByIdAsync(int id);

        Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto);

        Task<int> UpdateEmpAsync(UpdatedEmployeeDto employeeDto);

        Task<bool> DeleteEmpAsync(int id);


    }
}
