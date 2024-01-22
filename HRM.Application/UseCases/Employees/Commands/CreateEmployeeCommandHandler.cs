using AutoMapper;
using HRM.Application.UseCases.Employees.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Entities.Users;
using HRM.Domain.Enums;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandHandler(IUnitOfWork repository, IMapper mapper, UserManager<User> userManager, RoleService roleService)
    : IRequestHandler<CreateEmployeeCommand, NewEmployeeDto>
{
    public async Task<NewEmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(request);
        employee.Code = GenerateEmployeeCode();

        await repository.Employee.Add(employee);
        await repository.CommitAsync(cancellationToken);

        return new NewEmployeeDto { Id = employee.Id, Code = employee.Code, User = await CreateEmployeeUser(employee) };
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

    private async Task<EmployeeUserDto> CreateEmployeeUser(Employee employee)
    {
        var username = employee.Email.Split('@')[0];
        var password = GeneratePassword();
        var user = new User
        {
            UserName = username, Email = employee.Email, RefreshToken = Guid.NewGuid().ToString(),
            RefreshTokenExpiryTime = DateTime.Now.AddDays(-1)
        };

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded) throw new BadRequestException("Failed to create employee user");

        await userManager.AddToRoleAsync(user, Role.Employee.ToString());

        return new EmployeeUserDto { Username = username, Password = password };
    }

    private static string GeneratePassword()
    {
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string specialChars = "#$^+=!*()@%&";

        var random = new Random();
        var password = new char[6];

        // Ensure one character from each required set
        password[0] = upperCase[random.Next(upperCase.Length)];
        password[1] = lowerCase[random.Next(lowerCase.Length)];
        password[2] = digits[random.Next(digits.Length)];
        password[3] = specialChars[random.Next(specialChars.Length)];

        // Fill the rest of the password length with random characters from all sets
        const string allChars = upperCase + lowerCase + digits + specialChars;
        for (var i = 4; i < password.Length; i++) password[i] = allChars[random.Next(allChars.Length)];

        // Shuffle the password to prevent the predictable pattern
        password = password.OrderBy(x => random.Next()).ToArray();

        return new string(password);
    }
}