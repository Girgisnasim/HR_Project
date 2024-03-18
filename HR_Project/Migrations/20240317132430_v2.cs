using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Project.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_General_Rules_Rules_id",
                table: "HR");

            migrationBuilder.DropIndex(
                name: "IX_HR_Rules_id",
                table: "HR");

            migrationBuilder.DropColumn(
                name: "Rules_id",
                table: "HR");

            migrationBuilder.AddColumn<int>(
                name: "HR_id",
                table: "General_Rules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_General_Rules_HR_id",
                table: "General_Rules",
                column: "HR_id");

            migrationBuilder.AddForeignKey(
                name: "FK_General_Rules_HR_HR_id",
                table: "General_Rules",
                column: "HR_id",
                principalTable: "HR",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_General_Rules_HR_HR_id",
                table: "General_Rules");

            migrationBuilder.DropIndex(
                name: "IX_General_Rules_HR_id",
                table: "General_Rules");

            migrationBuilder.DropColumn(
                name: "HR_id",
                table: "General_Rules");

            migrationBuilder.AddColumn<int>(
                name: "Rules_id",
                table: "HR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Rules_id",
                table: "HR",
                column: "Rules_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_General_Rules_Rules_id",
                table: "HR",
                column: "Rules_id",
                principalTable: "General_Rules",
                principalColumn: "Id");
        }
    }
}
