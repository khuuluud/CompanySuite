using LinkDev.CompanySuite.DAL.Models.Department;
using LinkDev.CompanySuite.DAL.Persistance.Repositories.Depatments;
using LinkDev.CompanySutie.BLL.Moduls.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.CompanySutie.BLL.Services.Departments
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentService(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public IEnumerable<DepartmentToReturnDTO> GetAllDepartments()
        {
            var departments = _departmentRepo.GetAllAsIQueryable().Select(department => new DepartmentToReturnDTO
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate
            }).AsNoTracking().ToList();

            return departments;
        }
        public DepartmentToReturnDetailsDto? GetDepById(int id)
        {
            var department = _departmentRepo.GetById(id);

            if (department != null) { }
                return new DepartmentToReturnDetailsDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn

                };
            return null;
        }
        public int CreateDepartment(CreatedDepartmentDto department)
        {
            var createdDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow


            };
            return _departmentRepo.Add(createdDepartment);
        }

        public int UpdateDepartment(UpdatedDepartmentDto department)
        {
            var createdDepartment = new Department()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow


            };
            return _departmentRepo.Update(createdDepartment);
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepo.GetById(id);
            if (department is { })
                return _departmentRepo.Delete(department) > 0;
            return false;

        }

        Department? IDepartmentService.GetDepById(int id)
        {
            throw new NotImplementedException();
        }
    }


}
