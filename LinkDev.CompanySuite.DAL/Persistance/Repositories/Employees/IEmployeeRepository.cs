
using LinkDev.CompanySuite.DAL.Models.Employees;
using LinkDev.CompanySuite.DAL.Persistance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    
    }
}
