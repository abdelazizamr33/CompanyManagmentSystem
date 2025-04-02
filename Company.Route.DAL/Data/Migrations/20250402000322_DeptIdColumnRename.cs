using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Route.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeptIdColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeprtmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DeprtmentId",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeprtmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DeprtmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DeprtmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeprtmentId",
                table: "Employees",
                column: "DeprtmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
