
using LinkDev.CompanyBase.BLL.Moduls.DTO.Employees;
using LinkDev.CompanyBase.BLL.Services.Employees;

using Microsoft.AspNetCore.Mvc;

namespace LinkDev.CompanyBase.PL.Controllers
{
    public class EmployeeController : Controller
    {

        #region Services

        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _loger;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> loger, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _loger = loger;
            _environment = environment;

        }
        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();

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
        public IActionResult Create(CreatedEmployeeDto employee)
        {

            if (!ModelState.IsValid)
                return View(employee);
            var message = string.Empty;
            try
            {


                var result = _employeeService.CreateEmployee(employee);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {

                    message = "employee is not created";
                    ModelState.AddModelError(string.Empty, message);
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Employee is not created";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(employee);



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

            return View(new UpdatedEmployeeDto()
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
        public IActionResult Edit([FromRoute] int id, UpdatedEmployeeDto employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            var message = string.Empty;
            try
            {
               

                var Updated = _employeeService.UpdateEmp(employee) > 0;

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
            return View(employee);
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
