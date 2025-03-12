using Company.Route.BLL.Interfaces;
using Company.Route.DAL.Data.Contexts;
using Company.Route.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Repositories
{
    public class Employeerepository : GenericRepository<Employee>,IEmployeeInterface
    {


        public Employeerepository(CompanyDbContext context):base(context) // ASK CLR To Create object from DbContext
        {
            
        }

        #region Old Code Before Refactor
        //private readonly CompanyDbContext _context;

        //public Employeerepository(CompanyDbContext context)
        //{
        //    _context = context;
        //}
        //public IEnumerable<Employee> GetAll()
        //{
        //    return _context.Employees.ToList();
        //}
        //public Employee? Get(int id)
        //{
        //    return _context.Employees.Find(id);
        //}        
        //public int Add(Employee model)
        //{
        //    _context.Employees.Add(model);
        //    return _context.SaveChanges();
        //}
        //public int Update(Employee model)
        //{
        //    _context.Employees.Update(model);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Employee model)
        //{
        //    _context.Employees.Remove(model);
        //    return _context.SaveChanges();
        //} 
        #endregion

    }
}
