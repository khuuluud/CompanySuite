
using LinkDev.CompanyBase.DAL.Models.Employees;
using LinkDev.CompanyBase.DAL.Persistance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Persistance.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    
    }
}
