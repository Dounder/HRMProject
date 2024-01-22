using HRM.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data.Seed;

public static class EmployeeSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var departments = new Department[]
        {
            new() { Id = 1, Name = "Human Resource", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 2, Name = "Information Technology (IT)", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 3, Name = "Finance", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 4, Name = "Sales", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 5, Name = "Marketing", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 6, Name = "Operations", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 7, Name = "Customer Service", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 8, Name = "Research and Development (R&D)", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 9, Name = "Legal", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 10, Name = "Executive", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 11, Name = "None", CreatedAt = DateTime.Parse("2024-01-01") },
        };

        modelBuilder.Entity<Department>().HasData(departments);

        var positions = new Position[]
        {
            new() { Id = 1, Name = "HR Manager", DepartmentId = 1, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 2, Name = "HR Coordinator", DepartmentId = 1, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 3, Name = "HR Assistant", DepartmentId = 1, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 4, Name = "Recruitment Specialist", DepartmentId = 1, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 5, Name = "IT Manager", DepartmentId = 2, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 6, Name = "Network Administrator", DepartmentId = 2, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 7, Name = "Software Developer", DepartmentId = 2, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 8, Name = "Help Desk Technician", DepartmentId = 2, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 9, Name = "Finance Manager", DepartmentId = 3, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 10, Name = "Accountant", DepartmentId = 3, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 11, Name = "Financial Analyst", DepartmentId = 3, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 12, Name = "Payroll Specialist", DepartmentId = 3, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 13, Name = "Sales Manager", DepartmentId = 4, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 14, Name = "Sales Representative", DepartmentId = 4, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 15, Name = "Account Executive", DepartmentId = 4, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 16, Name = "Sales Analyst", DepartmentId = 4, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 17, Name = "Marketing Manager", DepartmentId = 5, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 18, Name = "Marketing Coordinator", DepartmentId = 5, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 19, Name = "Content Strategist", DepartmentId = 5, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 20, Name = "SEO Specialist", DepartmentId = 5, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 21, Name = "Operations Manager", DepartmentId = 6, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 22, Name = "Logistics Coordinator", DepartmentId = 6, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 23, Name = "Supply Chain Analyst", DepartmentId = 6, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 24, Name = "Production Planner", DepartmentId = 6, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 25, Name = "Customer Service Manager", DepartmentId = 7, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 26, Name = "Customer Service Representative", DepartmentId = 7, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 27, Name = "Support Specialist", DepartmentId = 7, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 28, Name = "R&D Manager", DepartmentId = 8, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 29, Name = "Product Developer", DepartmentId = 8, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 30, Name = "Research Scientist", DepartmentId = 8, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 31, Name = "R&D Engineer", DepartmentId = 8, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 32, Name = "Legal Counsel", DepartmentId = 9, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 33, Name = "Paralegal", DepartmentId = 9, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 34, Name = "Legal Assistant", DepartmentId = 9, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 35, Name = "Compliance Officer", DepartmentId = 9, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 36, Name = "CEO (Chief Executive Officer)", DepartmentId = 10, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 37, Name = "CFO (Chief Financial Officer)", DepartmentId = 10, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 38, Name = "CTO (Chief Technology Officer)", DepartmentId = 10, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 39, Name = "COO (Chief Operating Officer)", DepartmentId = 10, CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 40, Name = "None", DepartmentId = 11, CreatedAt = DateTime.Parse("2024-01-01") },
        };

        modelBuilder.Entity<Position>().HasData(positions);
    }
}