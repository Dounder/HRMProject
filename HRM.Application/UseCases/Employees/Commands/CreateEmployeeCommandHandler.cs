using AutoMapper;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<CreateEmployeeCommand, int>
{
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(request);
        employee.Code = GenerateEmployeeCode();

        await repository.Employee.Add(employee);
        await repository.CommitAsync(cancellationToken);

        return employee.Id;
    }

    private static string GenerateEmployeeCode()
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        var random = new Random();
        const int length = 10;
        var result = new char[length];
        for (var i = 0; i < length; i++) result[i] = characters[random.Next(characters.Length)];
        return new string(result);
    }
}