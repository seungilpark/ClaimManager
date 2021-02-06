using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimManager.Infrastructure.Migrations.ApplicationDb
{
    public partial class Broughtbacknavigationalproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaimCategoryId",
                table: "ClaimItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "ClaimItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "ClaimItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_ClaimCategoryId",
                table: "ClaimItems",
                column: "ClaimCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_ClaimId",
                table: "ClaimItems",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_CurrencyId",
                table: "ClaimItems",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_ClaimCategories_ClaimCategoryId",
                table: "ClaimItems",
                column: "ClaimCategoryId",
                principalTable: "ClaimCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_Claims_ClaimId",
                table: "ClaimItems",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_Currencies_CurrencyId",
                table: "ClaimItems",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_ClaimCategories_ClaimCategoryId",
                table: "ClaimItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_Claims_ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_Currencies_CurrencyId",
                table: "ClaimItems");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_ClaimCategoryId",
                table: "ClaimItems");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_CurrencyId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "ClaimCategoryId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ClaimItems");
        }
    }
}
