using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Project.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "General_Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discound = table.Column<double>(type: "float", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    OffDay1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffDay2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions_Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Department_Department_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HR_General_Rules_Rules_id",
                        column: x => x.Rules_id,
                        principalTable: "General_Rules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeaveTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AttendTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Dept_id = table.Column<int>(type: "int", nullable: true),
                    HR_id = table.Column<int>(type: "int", nullable: true),
                    Rules_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_General_Rules_Rules_id",
                        column: x => x.Rules_id,
                        principalTable: "General_Rules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_HR_HR_id",
                        column: x => x.HR_id,
                        principalTable: "HR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    HR_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_HR_HR_id",
                        column: x => x.HR_id,
                        principalTable: "HR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permissions_HR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HR_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions_HR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_HR_HR_HR_id",
                        column: x => x.HR_id,
                        principalTable: "HR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    LeaveTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AttendTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Emp_id = table.Column<int>(type: "int", nullable: true),
                    HR_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attend_Employee_Emp_id",
                        column: x => x.Emp_id,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attend_HR_HR_id",
                        column: x => x.HR_id,
                        principalTable: "HR",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emp_Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: true),
                    Holiday_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emp_Holiday_Employee_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emp_Holiday_Holiday_Holiday_id",
                        column: x => x.Holiday_id,
                        principalTable: "Holiday",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attend_Emp_id",
                table: "Attend",
                column: "Emp_id",
                unique: true,
                filter: "[Emp_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attend_HR_id",
                table: "Attend",
                column: "HR_id");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Holiday_Employee_id",
                table: "Emp_Holiday",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Holiday_Holiday_id",
                table: "Emp_Holiday",
                column: "Holiday_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Dept_id",
                table: "Employee",
                column: "Dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HR_id",
                table: "Employee",
                column: "HR_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Rules_id",
                table: "Employee",
                column: "Rules_id");

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_HR_id",
                table: "Holiday",
                column: "HR_id");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Rules_id",
                table: "HR",
                column: "Rules_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Department_Dept_id",
                table: "Permissions_Department",
                column: "Dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_HR_HR_id",
                table: "Permissions_HR",
                column: "HR_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attend");

            migrationBuilder.DropTable(
                name: "Emp_Holiday");

            migrationBuilder.DropTable(
                name: "Permissions_Department");

            migrationBuilder.DropTable(
                name: "Permissions_HR");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "HR");

            migrationBuilder.DropTable(
                name: "General_Rules");
        }
    }
}
