using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class contract_faxContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCombineFax",
                schema: "intelligent_factory_management",
                table: "contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaxRate",
                schema: "intelligent_factory_management",
                table: "contract",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCombineFax",
                schema: "intelligent_factory_management",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                schema: "intelligent_factory_management",
                table: "contract");
        }
    }
}
