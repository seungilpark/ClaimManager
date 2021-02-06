using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimManager.Infrastructure.Migrations.ApplicationDb
{
    public partial class removednavpropagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_ClaimCategories_ClaimCategoryId",
                table: "ClaimItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_ClaimItems_ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_ClaimCategoryId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ClaimCategoryId",
                table: "ClaimItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaimItemId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClaimCategoryId",
                table: "ClaimItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ClaimItemId",
                table: "Currencies",
                column: "ClaimItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_ClaimCategoryId",
                table: "ClaimItems",
                column: "ClaimCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_ClaimCategories_ClaimCategoryId",
                table: "ClaimItems",
                column: "ClaimCategoryId",
                principalTable: "ClaimCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_ClaimItems_ClaimItemId",
                table: "Currencies",
                column: "ClaimItemId",
                principalTable: "ClaimItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
