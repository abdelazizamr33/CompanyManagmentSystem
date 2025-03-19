using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeInterface _EmployeeRepository;

        public EmployeeController(IEmployeeInterface EmployeeRepository) { 
            _EmployeeRepository = EmployeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _EmployeeRepository.GetAll();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO model)
        {
            if (ModelState.IsValid) 
            {
                var employee = new Employee() 
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    IsActive=model.IsActive,
                    IsDeleted=model.IsDeleted,
                    HirringDate=model.HirringDate,
                    CreateAt=model.CreateAt,
                };
                var count = _EmployeeRepository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");
            var result = _EmployeeRepository.Get(id.Value);

            if (result is null) return NotFound(new { StatusCode = 404, Message = $"Employee with Id: {id} is Not found" });

            return View(result);
        }
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");
            var result = _EmployeeRepository.Get(id.Value);

            if (result is null) return NotFound(new { StatusCode = 404, Message = $"Department with Id: {id} is Not found" });

            return View(result);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {
                if (id == model.Id)
                {
                    var result = _EmployeeRepository.Update(model);
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
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");
            var result = _EmployeeRepository.Get(id.Value);

            if (result is null) return NotFound(new { StatusCode = 404, Message = $"Employee with Id: {id} is Not found" });

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {
                if (id == model.Id)
                {
                    var result = _EmployeeRepository.Delete(model);
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
