using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class employee_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                schema: "intelligent_factory_management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingYear = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee",
                schema: "intelligent_factory_management");
        }
    }
}
