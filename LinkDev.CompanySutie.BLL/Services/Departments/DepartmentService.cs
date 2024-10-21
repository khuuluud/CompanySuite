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

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _unitOfWork.DepartmentRepository
                .GetAllAsIQueryable()
                .Where(D => !D.IsDeleted)
                .Select(department => new DepartmentDTO
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate
            }).AsNoTracking().ToListAsync();

            return departments;
        }
        public async Task<DepartmentDetailsDto?> GetDepByIdAsync(int id)
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

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
        public async Task<int> CreateDepartmentAsync(CreatedDepartmentDto department)
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
            return await _unitOfWork.CompleteAsync();
        }

        public async Task <int> UpdateDepartmentAsync(UpdatedDepartmentDto department)
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
            return  await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var deprepo = _unitOfWork.DepartmentRepository;
            var department =await deprepo.GetByIdAsync(id);
            if (department is { })
                 deprepo.Delete(department);
            return await _unitOfWork.CompleteAsync() > 0;

        }

     
    }


}
