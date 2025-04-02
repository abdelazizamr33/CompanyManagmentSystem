using AutoMapper;
using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace Company.Route.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeInterface _EmployeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeInterface EmployeeRepository,
            IDepartmentRepository departmentRepository
            ,IMapper mapper) { 
            _EmployeeRepository = EmployeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<Employee> employees ;
            if (SearchInput.IsNullOrEmpty())
            {
                employees = _EmployeeRepository.GetAll();

            }
            else
            {
                employees = _EmployeeRepository.GetByName(SearchInput);
            }
            // View ->
            // Dictionary : Key ,Data
            // 1 viewData : Transfer Extra Info. from Controller "Action" to View
            //ViewData["Message"] = "Hello From ViewData";
            // 2 ViewBag  : Transfer Extra Info. from Controller "Action" to View
            //ViewBag.Message = "Hello From ViewBag";
            // 3 TempData : 
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var department = _departmentRepository.GetAll();
            ViewData["departments"] = department;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO model)
        {
            if (ModelState.IsValid) 
            {
                //var employee = new Employee() 
                //{
                //    Name = model.Name,
                //    Age = model.Age,
                //    Email = model.Email,
                //    Address = model.Address,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    IsActive=model.IsActive,
                //    IsDeleted=model.IsDeleted,
                //    HirringDate=model.HirringDate,
                //    CreateAt=model.CreateAt,
                //    DeprtmentId=model.DepartmentId,
                //};
                var employee=_mapper.Map<Employee>(model);
                var count = _EmployeeRepository.Add(employee);
                if (count > 0)
                {
                    TempData["Message"] = "Employee is Created";
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
            var department = _departmentRepository.GetAll();
            ViewData["departments"] = department;
            if (result is null) return NotFound(new { StatusCode = 404, Message = $"Employee with Id: {id} is Not found" });

            return View(result);
        }
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");
            var result = _EmployeeRepository.Get(id.Value);
            var department = _departmentRepository.GetAll();
            ViewData["departments"] = department;

            if (result is null) return NotFound(new { StatusCode = 404, Message = $"Department with Id: {id} is Not found" });
            var dto = _mapper.Map<CreateEmployeeDTO>(result);

            return View(dto);
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
            var department = _departmentRepository.GetAll();
            ViewData["departments"] = department;
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
