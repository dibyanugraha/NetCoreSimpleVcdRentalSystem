using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspMvcFrontEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalLedgerEntries",
                columns: table => new
                {
                    EntryNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VcdId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    RentalOrderId = table.Column<int>(nullable: false),
                    RentDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalLedgerEntries", x => x.EntryNo);
                });

            migrationBuilder.CreateTable(
                name: "RentalPackageModel",
                columns: table => new
                {
                    RentalPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageName = table.Column<string>(nullable: true),
                    CostPerMonth = table.Column<decimal>(nullable: false),
                    MaxVcdRental = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPackageModel", x => x.RentalPackageId);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    IsMemberOfAnotherRental = table.Column<bool>(nullable: false),
                    Reference = table.Column<int>(nullable: false),
                    SubscribePackageRentalPackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                    table.ForeignKey(
                        name: "FK_Tenants_RentalPackageModel_SubscribePackageRentalPackageId",
                        column: x => x.SubscribePackageRentalPackageId,
                        principalTable: "RentalPackageModel",
                        principalColumn: "RentalPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    TenantModelTenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Tenants_TenantModelTenantId",
                        column: x => x.TenantModelTenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalOrders",
                columns: table => new
                {
                    RentalOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNo = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    BillToTenantTenantId = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalOrders", x => x.RentalOrderId);
                    table.ForeignKey(
                        name: "FK_RentalOrders_Tenants_BillToTenantTenantId",
                        column: x => x.BillToTenantTenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vcds",
                columns: table => new
                {
                    VcdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VcdName = table.Column<string>(nullable: true),
                    VcdBoughtDate = table.Column<DateTime>(nullable: true),
                    RentalOrderModelRentalOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vcds", x => x.VcdId);
                    table.ForeignKey(
                        name: "FK_Vcds_RentalOrders_RentalOrderModelRentalOrderId",
                        column: x => x.RentalOrderModelRentalOrderId,
                        principalTable: "RentalOrders",
                        principalColumn: "RentalOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TenantModelTenantId",
                table: "Contacts",
                column: "TenantModelTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalOrders_BillToTenantTenantId",
                table: "RentalOrders",
                column: "BillToTenantTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_SubscribePackageRentalPackageId",
                table: "Tenants",
                column: "SubscribePackageRentalPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vcds_RentalOrderModelRentalOrderId",
                table: "Vcds",
                column: "RentalOrderModelRentalOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "RentalLedgerEntries");

            migrationBuilder.DropTable(
                name: "Vcds");

            migrationBuilder.DropTable(
                name: "RentalOrders");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "RentalPackageModel");
        }
    }
}
