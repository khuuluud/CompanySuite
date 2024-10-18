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
        IEnumerable<EmployeeDTO> GetEmployees(string search);

        EmployeeDetailsDto GetEmpById(int id);

        int CreateEmployee(CreatedEmployeeDto employeeDto);

        int UpdateEmp(UpdatedEmployeeDto employeeDto);

        bool DeleteEmp(int id);


    }
}
