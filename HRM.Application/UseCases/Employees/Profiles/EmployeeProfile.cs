using AutoMapper;
using HRM.Application.UseCases.Employees.Commands;
using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Entities.Employees;

namespace HRM.Application.UseCases.Employees.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Employee, EmployeeDetailDto>();
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

        CreateMap<Department, DepartmentDto>();
        CreateMap<Position, PositionDto>();
    }
}