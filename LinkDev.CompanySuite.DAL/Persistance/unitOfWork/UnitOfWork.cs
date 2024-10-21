﻿using LinkDev.CompanyBase.DAL.Persistance.Data;
using LinkDev.CompanyBase.DAL.Persistance.Repositories.Depatments;
using LinkDev.CompanyBase.DAL.Persistance.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanyBase.DAL.Persistance.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_dbContext);
     
        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }




        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
           await _dbContext.DisposeAsync();
        }
    }
}
