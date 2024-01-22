using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TimeTracking_Module : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeTrackings_EmployeeId",
                table: "TimeTrackings");

            migrationBuilder.AlterColumn<double>(
                name: "TotalHours",
                table: "TimeTrackings",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOut",
                table: "TimeTrackings",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeTrackings",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LunchIn",
                table: "TimeTrackings",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LunchOut",
                table: "TimeTrackings",
                type: "time",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "UpdatedAt", "UserId" },
                values: new object[] { 5, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Employee", "EMPLOYEE", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "bcee7468-91cf-468d-bd6b-7fcd42ff2728", new DateTime(2024, 1, 22, 17, 40, 18, 927, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_EmployeeId_Date",
                table: "TimeTrackings",
                columns: new[] { "EmployeeId", "Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeTrackings_EmployeeId_Date",
                table: "TimeTrackings");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeTrackings");

            migrationBuilder.DropColumn(
                name: "LunchIn",
                table: "TimeTrackings");

            migrationBuilder.DropColumn(
                name: "LunchOut",
                table: "TimeTrackings");

            migrationBuilder.AlterColumn<double>(
                name: "TotalHours",
                table: "TimeTrackings",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2,
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOut",
                table: "TimeTrackings",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "a1ab592b-3d0b-4ad3-8ad1-846cb272100b", new DateTime(2024, 1, 22, 14, 36, 15, 471, DateTimeKind.Utc).AddTicks(4043) });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_EmployeeId",
                table: "TimeTrackings",
                column: "EmployeeId");
        }
    }
}
