using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Employee_Module : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraHourRate = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalHours = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    TotalExtraHours = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTrackings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "7a9c124b-09d1-40e9-bd81-47d4ae58a016", new DateTime(2024, 1, 19, 4, 11, 14, 406, DateTimeKind.Utc).AddTicks(9288), "AQAAAAIAAYagAAAAEDT3FSInfiwXnn0qodmGjgWfPVdI8IvR3Rs150lJrAOmifMUD5X4YYITmdAdagnq8g==", "16a4e3be-6976-4acd-9af9-d1e5af199c0f", new DateTime(2024, 1, 18, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7230), "37350b27-f5cc-4966-b83e-71df3ee638a9" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7658), null, "Human Resource", null },
                    { 2, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7661), null, "Information Technology (IT)", null },
                    { 3, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7662), null, "Finance", null },
                    { 4, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7663), null, "Sales", null },
                    { 5, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7663), null, "Marketing", null },
                    { 6, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7664), null, "Operations", null },
                    { 7, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7665), null, "Customer Service", null },
                    { 8, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7666), null, "Research and Development (R&D)", null },
                    { 9, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7666), null, "Legal", null },
                    { 10, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7667), null, "Executive", null },
                    { 11, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7668), null, "None", null }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DepartmentId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7829), null, 1, "HR Manager", null },
                    { 2, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7831), null, 1, "HR Coordinator", null },
                    { 3, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7832), null, 1, "HR Assistant", null },
                    { 4, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7833), null, 1, "Recruitment Specialist", null },
                    { 5, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7834), null, 2, "IT Manager", null },
                    { 6, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7834), null, 2, "Network Administrator", null },
                    { 7, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7836), null, 2, "Software Developer", null },
                    { 8, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7836), null, 2, "Help Desk Technician", null },
                    { 9, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7837), null, 3, "Finance Manager", null },
                    { 10, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7838), null, 3, "Accountant", null },
                    { 11, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7839), null, 3, "Financial Analyst", null },
                    { 12, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7840), null, 3, "Payroll Specialist", null },
                    { 13, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7841), null, 4, "Sales Manager", null },
                    { 14, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7842), null, 4, "Sales Representative", null },
                    { 15, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7843), null, 4, "Account Executive", null },
                    { 16, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7844), null, 4, "Sales Analyst", null },
                    { 17, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7845), null, 5, "Marketing Manager", null },
                    { 18, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7845), null, 5, "Marketing Coordinator", null },
                    { 19, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7846), null, 5, "Content Strategist", null },
                    { 20, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7847), null, 5, "SEO Specialist", null },
                    { 21, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7847), null, 6, "Operations Manager", null },
                    { 22, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7848), null, 6, "Logistics Coordinator", null },
                    { 23, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7849), null, 6, "Supply Chain Analyst", null },
                    { 24, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7850), null, 6, "Production Planner", null },
                    { 25, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7850), null, 7, "Customer Service Manager", null },
                    { 26, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7851), null, 7, "Customer Service Representative", null },
                    { 27, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7852), null, 7, "Support Specialist", null },
                    { 28, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7853), null, 8, "R&D Manager", null },
                    { 29, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7853), null, 8, "Product Developer", null },
                    { 30, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7854), null, 8, "Research Scientist", null },
                    { 31, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7855), null, 8, "R&D Engineer", null },
                    { 32, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7856), null, 9, "Legal Counsel", null },
                    { 33, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7856), null, 9, "Paralegal", null },
                    { 34, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7857), null, 9, "Legal Assistant", null },
                    { 35, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7858), null, 9, "Compliance Officer", null },
                    { 36, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7859), null, 10, "CEO (Chief Executive Officer)", null },
                    { 37, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7859), null, 10, "CFO (Chief Financial Officer)", null },
                    { 38, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7860), null, 10, "CTO (Chief Technology Officer)", null },
                    { 39, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7861), null, 10, "COO (Chief Operating Officer)", null },
                    { 40, new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7862), null, 11, "None", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Id_Name",
                table: "Departments",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Code",
                table: "Employees",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Id_Name",
                table: "Positions",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_EmployeeId",
                table: "TimeTrackings",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTrackings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "332082d0-28e1-466d-92e7-21b243cba8d6", new DateTime(2024, 1, 19, 3, 23, 39, 525, DateTimeKind.Utc).AddTicks(3093), "AQAAAAIAAYagAAAAEBng1UsRAy0PoM7US36tIOxY6hac4defwoZduf/AzJgTxXMiqv6buLmzFjg+kRjTCw==", "57dbc86a-3fbe-42ea-887e-47f78ec57f58", new DateTime(2024, 1, 18, 3, 23, 39, 576, DateTimeKind.Utc).AddTicks(813), "1845ef30-3c52-443f-ba69-f629fcbd463c" });
        }
    }
}
