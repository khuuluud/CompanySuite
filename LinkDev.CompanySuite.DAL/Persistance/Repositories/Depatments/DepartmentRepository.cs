﻿using LinkDev.CompanyBase.DAL.Models.Departments;
using LinkDev.CompanyBase.DAL.Persistance.Data;
using LinkDev.CompanyBase.DAL.Persistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Persistance.Repositories.Depatments
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            
        }

    }
}