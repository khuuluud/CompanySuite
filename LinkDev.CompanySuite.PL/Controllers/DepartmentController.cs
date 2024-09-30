using LinkDev.CompanySuite.DAL.Models.Department;
using LinkDev.CompanySuite.PL.ViewModels.Departments;
using LinkDev.CompanySutie.BLL.Moduls.DTO;
using LinkDev.CompanySutie.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.CompanySuite.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {

            if (!ModelState.IsValid)
                return View(department);
            var message = string.Empty;
            try
            {


                var result = _departmentService.CreateDepartment(department);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {

                    message = "Department is not created";
                    ModelState.AddModelError(string.Empty, message);
                }
                return View(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Department is not created";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(department);



        }


        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepById(id.Value);

            if (department is null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepById(id.Value);

            if (department is null)
                return NotFound();

            return View(new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate
            });

        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id ,DepartmentEditViewModel departmentVM)
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
    }
}
