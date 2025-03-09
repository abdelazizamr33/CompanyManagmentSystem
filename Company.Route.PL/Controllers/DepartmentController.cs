using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO model)
        {
            if(ModelState.IsValid) // Server side Validation for data coming from form
            {
                var department = new Department() // Mapping
                {
                    Code=model.Code,
                    Name=model.Name,
                    CreateAt=model.CreateAt,
                };
                var count=_departmentRepository.Add(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
