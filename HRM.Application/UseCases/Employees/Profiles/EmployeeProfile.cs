using AutoMapper;
using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Entities.Employees;

namespace HRM.Application.UseCases.Employees.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Department, DepartmentDto>();
        CreateMap<Position, PositionDto>();
    }
}