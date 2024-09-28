using LinkDev.CompanySuite.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories.Depatments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool withAsNoTracking = false);

        IQueryable<Department> GetAllAsIQueryable();

        Department? GetById(int id);

        int Add(Department entity);

        int Update(Department entity);

        int Delete(Department entity);


    }
}
