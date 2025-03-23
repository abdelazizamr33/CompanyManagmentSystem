using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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

        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details")
        {
            if (id is null) return BadRequest("Invalid Id");
            var result=_departmentRepository.Get(id.Value);

            if(result is null) return NotFound(new {StatusCode=404,Message=$"Department with Id: {id} is Not found"});

            return View(viewName,result);
        }
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id");
            //var result = _departmentRepository.Get(id.Value);

            //if (result is null) return NotFound(new { StatusCode = 404, Message = $"Department with Id: {id} is Not found" });

            return Details(id, "Edit");
        }
        
        //[HttpPost]
        //public IActionResult Edit([FromRoute]int id,Department model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == model.Id)
        //        {
        //            var result = _departmentRepository.Update(model);
        //            if (result > 0)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        else
        //            return BadRequest();
        //    }

        //    return View(model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken] // htmn3 ay 7ad y3ml request mngheer elForm ya3ni PostMan Cannot use
        public IActionResult Edit([FromRoute] int id, UpdateDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt,
                };
                var result = _departmentRepository.Update(department);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                    return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id");
            //var result = _departmentRepository.Get(id.Value);

            //if (result is null) return NotFound(new { StatusCode = 404, Message = $"Department with Id: {id} is Not found" });

            return Details(id, "Delete");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department model)
        {
            if (ModelState.IsValid)
            {
                if (id == model.Id)
                {
                    var result = _departmentRepository.Delete(model);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                    return BadRequest();
            }

            return View(model);
        }
    }
}
