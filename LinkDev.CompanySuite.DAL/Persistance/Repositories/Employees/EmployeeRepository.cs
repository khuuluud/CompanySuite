
using LinkDev.CompanySuite.DAL. Models.Employees;
using LinkDev.CompanySuite.DAL.Persistance.Data;
using LinkDev.CompanySuite.DAL.Persistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
