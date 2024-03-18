using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Project.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attend_Emp_id",
                table: "Attend");

            migrationBuilder.CreateIndex(
                name: "IX_Attend_Emp_id",
                table: "Attend",
                column: "Emp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attend_Emp_id",
                table: "Attend");

            migrationBuilder.CreateIndex(
                name: "IX_Attend_Emp_id",
                table: "Attend",
                column: "Emp_id",
                unique: true,
                filter: "[Emp_id] IS NOT NULL");
        }
    }
}
