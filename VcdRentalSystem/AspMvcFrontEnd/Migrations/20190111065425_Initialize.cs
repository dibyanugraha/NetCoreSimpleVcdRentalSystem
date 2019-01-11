using Microsoft.EntityFrameworkCore.Migrations;

namespace AspMvcFrontEnd.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Tenants_TenantModelTenantId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_TenantModelTenantId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "TenantModelTenantId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "VcdName",
                table: "Vcds",
                newName: "VcdTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VcdTitle",
                table: "Vcds",
                newName: "VcdName");

            migrationBuilder.AddColumn<int>(
                name: "TenantModelTenantId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TenantModelTenantId",
                table: "Contacts",
                column: "TenantModelTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Tenants_TenantModelTenantId",
                table: "Contacts",
                column: "TenantModelTenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
