﻿using Company.Route.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.DAL.Data.Contexts
{
    public class CompanyDbContext:DbContext
    {
        //public CompanyDbContext() :base()
        //{

        //}
        // instead of this ^ we will write this one

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=CompanyMS; Trusted_Connection=True; TrustServerCertficate=True");
        //}
        public DbSet<Department> Departments { get; set; }
    }
}
