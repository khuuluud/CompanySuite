using LinkDev.CompanySuite.DAL.Models.Department;
using LinkDev.CompanySuite.DAL.Persistance.Data;
using LinkDev.CompanySuite.DAL.Persistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories.Depatments
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            
        }

    }
}