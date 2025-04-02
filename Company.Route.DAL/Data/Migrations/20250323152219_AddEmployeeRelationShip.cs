using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Route.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeprtmentId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeprtmentId",
                table: "Employees",
                column: "DeprtmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeprtmentId",
                table: "Employees",
                column: "DeprtmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeprtmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DeprtmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeprtmentId",
                table: "Employees");
        }
    }
}
