using LinkDev.CompanyBase.DAL.Models.Departments;
using LinkDev.CompanyBase.PL.ViewModels.Departments;
using LinkDev.CompanyBase.BLL.Moduls.DTO;
using LinkDev.CompanyBase.BLL.Moduls.DTO.Departments;
using LinkDev.CompanyBase.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace LinkDev.CompanyBase.PL.Controllers
{
    public class DepartmentController : Controller
    {

        #region Services

        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment , IMapper Mapper)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
            _mapper = Mapper;
        }

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {

            if (!ModelState.IsValid)
                return View(departmentVM);
            var message = string.Empty;
            try
            {
               var CreatedDepartment = new CreatedDepartmentDto()
                {
                    
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate

                };

                var created = _departmentService.CreateDepartment(CreatedDepartment) > 0;


                if (created)
                
                    TempData["Message"] = "Department has been created successfully";

                else
                
                    TempData["Message"] = "Department has not been created successfully";
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Department is not created";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(departmentVM);



        }

        #endregion

        #region Details 

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepById(id.Value);

            if (department is null)
                return NotFound();

            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepById(id.Value);

            if (department is null)
                return NotFound();

            var departmentVM = _mapper.Map<DepartmentDetailsDto, DepartmentViewModel>(department);

          return View(departmentVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
                return View(departmentVM);
            var message = string.Empty;
            try
            {
                var departmentToUpdate = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate

                };

                var Updated = _departmentService.UpdateDepartment(departmentToUpdate) > 0;

                if (Updated)
                    return RedirectToAction(nameof(Index));

                message = "Department is not updated";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Department is not updated";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(departmentVM);
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepById(id.Value);

            if (department is null)
                return NotFound();
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _departmentService.DeleteDepartment(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));


                message = "The department has not been deleted";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Department is not updated";

            }

            //ModelState.AddModelError(string.Empty, message);
            return RedirectToAction(nameof(Index));

        } 
        #endregion


    }
}
