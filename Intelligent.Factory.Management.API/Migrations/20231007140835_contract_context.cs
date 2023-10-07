using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class contract_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogisticsUndertaker",
                schema: "intelligent_factory_management",
                table: "contract",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipDateTime",
                schema: "intelligent_factory_management",
                table: "contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShipType",
                schema: "intelligent_factory_management",
                table: "contract",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogisticsUndertaker",
                schema: "intelligent_factory_management",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "ShipDateTime",
                schema: "intelligent_factory_management",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "ShipType",
                schema: "intelligent_factory_management",
                table: "contract");
        }
    }
}
