
using LinkDev.CompanyBase.BLL.Moduls.DTO.Employees;
using LinkDev.CompanyBase.BLL.Services.Departments;
using LinkDev.CompanyBase.BLL.Services.Employees;
using LinkDev.CompanyBase.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.CompanyBase.PL.Controllers
{
    public class EmployeeController : Controller
    {

        #region Services

        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _loger;
        private readonly IWebHostEnvironment _environment;
        private readonly IDepartmentService? _departmentService;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> loger, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _loger = loger;
            _environment = environment;
            
        }
        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index(string search)
        {
            var employees = _employeeService.GetEmployees(search);

            return View(employees);
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
        public IActionResult Create(EmployeeViewmodel employeeVM)
        {

            if (!ModelState.IsValid)
                return View(employeeVM);
            var message = string.Empty;
            try
            {

                var CreatedEmp = new CreatedEmployeeDto()
                {
                    Name = employeeVM.Name,
                    Age = employeeVM.Age,
                    Email = employeeVM.Email,
                    Address = employeeVM.Address,
                    Salary = employeeVM.Salary,
                    PhoneNumber = employeeVM.PhoneNumber,
                    Gender = employeeVM.Gender,
                    EmployeeType = employeeVM.EmployeeType,
                    IsActive = employeeVM.IsActive,
                    DepartmentId= employeeVM.DepartmentId,



                };


                var result = _employeeService.CreateEmployee(CreatedEmp);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {

                    message = "employee is not created";
                    ModelState.AddModelError(string.Empty, message);
                }
                return View(employeeVM);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Employee is not created";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(employeeVM);



        }

        #endregion

        #region Details 

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetEmpById(id.Value);

            if (employee is null)
                return NotFound();

            return View(employee);
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
          
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetEmpById(id.Value);

            if (employee is null)
                return NotFound();

           
            return View(new EmployeeViewmodel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Address = employee.Address,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,

            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewmodel employeeVM)
        {
            if (!ModelState.IsValid)
                return View(employeeVM);
            var message = string.Empty;
            try
            {
                var UpdatedEmp = new UpdatedEmployeeDto()
                {
                    Id = id,
                    Name = employeeVM.Name,
                    Age = employeeVM.Age,
                    Email = employeeVM.Email,
                    Address = employeeVM.Address,
                    Salary = employeeVM.Salary,
                    PhoneNumber = employeeVM.PhoneNumber,
                    Gender = employeeVM.Gender,
                    EmployeeType = employeeVM.EmployeeType,
                    IsActive = employeeVM.IsActive,



                };

                var Updated = _employeeService.UpdateEmp(UpdatedEmp) > 0;

                if (Updated)
                    return RedirectToAction(nameof(Index));

                message = "employee is not updated";
            }
            catch (Exception ex)
            {
                _loger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "employee is not updated";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(employeeVM);
        }
        #endregion

       #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetEmpById(id.Value);

            if (employee is null)
                return NotFound();
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteEmp(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));


                message = "The employee has not been deleted";
            }
            catch (Exception ex)
            {
                _loger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "employee is not updated";

            }

            //ModelState.AddModelError(string.Empty, message);
            return RedirectToAction(nameof(Index));

        }
        #endregion

    }
}
