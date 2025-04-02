using AutoMapper;
using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;

namespace Company.Route.PL.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDTO, Employee>().ForMember(D=>D.DepartmentId,S=>S.MapFrom(O=>O.DepartmentId));
            CreateMap<Employee,CreateEmployeeDTO>();
        }
    }
}
