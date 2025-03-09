using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    // MVC Controller
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        //Ask CLR Craete object from departmentRepository
        // Dependency Injection
        public DepartmentController(IDepartmentRepository departmentRepository) //implement against interface not concrete class instead of "DepartmentRepository" use "IDepartmentRepository"
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet] // GET : /Department/Index
        public IActionResult Index()
        {
            var departments= _departmentRepository.GetAll();
            return View(departments);
        }
    }
}
