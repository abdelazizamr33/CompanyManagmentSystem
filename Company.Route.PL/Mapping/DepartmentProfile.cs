using AutoMapper;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;

namespace Company.Route.PL.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();
        }
    }
}
