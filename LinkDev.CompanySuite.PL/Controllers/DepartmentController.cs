using LinkDev.CompanySutie.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.CompanySuite.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
