using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent.Factory.Management.API.Migrations
{
    public partial class Init_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "intelligent_factory_management");

            migrationBuilder.CreateTable(
                name: "clientAgent",
                schema: "intelligent_factory_management",
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
                name: "contract",
                schema: "intelligent_factory_management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PayPercent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "intelligent_factory_management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryCriteria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "intelligent_factory_management",
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
                        principalSchema: "intelligent_factory_management",
                        principalTable: "clientAgent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contractContext",
                schema: "intelligent_factory_management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsIndependent = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contractContext_contract_ContractId",
                        column: x => x.ContractId,
                        principalSchema: "intelligent_factory_management",
                        principalTable: "contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productItem",
                schema: "intelligent_factory_management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productItem_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "intelligent_factory_management",
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_ClientAgentId",
                schema: "intelligent_factory_management",
                table: "client",
                column: "ClientAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_contractContext_ContractId",
                schema: "intelligent_factory_management",
                table: "contractContext",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_productItem_ProductId",
                schema: "intelligent_factory_management",
                table: "productItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client",
                schema: "intelligent_factory_management");

            migrationBuilder.DropTable(
                name: "contractContext",
                schema: "intelligent_factory_management");

            migrationBuilder.DropTable(
                name: "productItem",
                schema: "intelligent_factory_management");

            migrationBuilder.DropTable(
                name: "clientAgent",
                schema: "intelligent_factory_management");

            migrationBuilder.DropTable(
                name: "contract",
                schema: "intelligent_factory_management");

            migrationBuilder.DropTable(
                name: "product",
                schema: "intelligent_factory_management");
        }
    }
}
