using LinkDev.CompanyBase.DAL.Models.Departments;
using LinkDev.CompanyBase.DAL.Persistance.Repositories.Depatments;
using LinkDev.CompanyBase.BLL.Moduls.DTO.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.CompanyBase.DAL.Persistance.unitOfWork;

namespace LinkDev.CompanyBase.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository
                .GetAllAsIQueryable()
                .Where(D => !D.IsDeleted)
                .Select(department => new DepartmentDTO
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate
            }).AsNoTracking().ToList();

            return departments;
        }
        public DepartmentDetailsDto? GetDepById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

            if (department != null) {
                return new DepartmentDetailsDto()
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
            }
            
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
             _unitOfWork.DepartmentRepository.Add(createdDepartment);
            return _unitOfWork.Complete();
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
            _unitOfWork.DepartmentRepository.Update(createdDepartment);
            return _unitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
            var deprepo = _unitOfWork.DepartmentRepository;
            var department = deprepo.GetById(id);
            if (department is { })
                 deprepo.Delete(department);
            return _unitOfWork.Complete() > 0;

        }

       
    }


}
