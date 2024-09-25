using LinkDev.CompanySuite.DAL.Models.Department;
using LinkDev.CompanySuite.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySuite.DAL.Persistance.Repositories.Depatments
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public IEnumerable<Department> GetAll(bool withAsNoTracking = false)
        {
            if (withAsNoTracking)
                return _DbContext.Departments.AsNoTracking().ToList();
            return _DbContext.Departments.ToList();
        }

        public int Add(Department entity)
        {
            _DbContext.Departments.Add(entity);
            return _DbContext.SaveChanges();
        }

        public Department? GetById(int id)
        {
            return _DbContext.Departments.Find(id);
        }

        public int Update(Department entity)
        {
            _DbContext.Departments.Update(entity);
            return _DbContext.SaveChanges();
        }   
        
        public int Delete(Department entity)
        {
            _DbContext.Departments.Remove(entity);
            return _DbContext.SaveChanges();
        }
    }
}
