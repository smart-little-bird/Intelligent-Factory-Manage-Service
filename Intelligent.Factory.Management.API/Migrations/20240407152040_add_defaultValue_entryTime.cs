using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class add_defaultValue_entryTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryTime",
                schema: "intelligent_factory_management",
                table: "employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 23, 20, 40, 884, DateTimeKind.Local).AddTicks(9854));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryTime",
                schema: "intelligent_factory_management",
                table: "employee");
        }
    }
}
