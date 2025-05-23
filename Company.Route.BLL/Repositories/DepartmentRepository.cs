﻿using Company.Route.BLL.Interfaces;
using Company.Route.DAL.Data.Contexts;
using Company.Route.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext context):base(context)
        {
            
        }
        #region Old Code Before refactor
        //private readonly CompanyDbContext _context; // readonly -> make no one can assign value to it
        //public DepartmentRepository(CompanyDbContext context)
        //{
        //    _context = context;
        //}
        //public IEnumerable<Department> GetAll()
        //{
        //    return _context.Departments.ToList();
        //}
        //public Department? Get(int id)
        //{
        //    return _context.Departments.Find(id);
        //}
        //public int Add(Department model)
        //{
        //    _context.Departments.Add(model);
        //    return _context.SaveChanges();
        //}
        //public int Update(Department model)
        //{
        //    _context.Departments.Update(model);
        //    return _context.SaveChanges();
        //}
        //public int Delete(Department model)
        //{
        //    _context.Departments.Remove(model);
        //    return _context.SaveChanges();
        //} 
        #endregion
    }
}
