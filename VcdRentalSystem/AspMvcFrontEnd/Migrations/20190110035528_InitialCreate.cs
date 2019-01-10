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
                name: "ContactModel",
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
                    table.PrimaryKey("PK_ContactModel", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ContactModel_Tenants_TenantModelTenantId",
                        column: x => x.TenantModelTenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactModel_TenantModelTenantId",
                table: "ContactModel",
                column: "TenantModelTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_SubscribePackageRentalPackageId",
                table: "Tenants",
                column: "SubscribePackageRentalPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactModel");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "RentalPackageModel");
        }
    }
}
