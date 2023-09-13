using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class context_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IntelligentFactoryManagement");

            migrationBuilder.CreateTable(
                name: "clientAgent",
                schema: "IntelligentFactoryManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "IntelligentFactoryManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAgentId = table.Column<int>(type: "int", nullable: false),
                    TFN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_clientAgent_ClientAgentId",
                        column: x => x.ClientAgentId,
                        principalSchema: "IntelligentFactoryManagement",
                        principalTable: "clientAgent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_ClientAgentId",
                schema: "IntelligentFactoryManagement",
                table: "client",
                column: "ClientAgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client",
                schema: "IntelligentFactoryManagement");

            migrationBuilder.DropTable(
                name: "clientAgent",
                schema: "IntelligentFactoryManagement");
        }
    }
}
