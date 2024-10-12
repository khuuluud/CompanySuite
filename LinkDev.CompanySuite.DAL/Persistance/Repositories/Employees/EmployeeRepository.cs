
using LinkDev.CompanyBase.DAL. Models.Employees;
using LinkDev.CompanyBase.DAL.Persistance.Data;
using LinkDev.CompanyBase.DAL.Persistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.CompanyBase.DAL.Persistance.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
