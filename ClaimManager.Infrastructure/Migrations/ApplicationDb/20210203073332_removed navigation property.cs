using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimManager.Infrastructure.Migrations.ApplicationDb
{
    public partial class removednavigationproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_Claims_ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimItems_Currencies_CurrencyId",
                table: "ClaimItems");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropIndex(
                name: "IX_ClaimItems_CurrencyId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ClaimItems");

            migrationBuilder.AddColumn<int>(
                name: "ClaimItemId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClaimItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ClaimItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ClaimItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "ClaimItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ClaimItemId",
                table: "Currencies",
                column: "ClaimItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_ClaimItems_ClaimItemId",
                table: "Currencies",
                column: "ClaimItemId",
                principalTable: "ClaimItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_ClaimItems_ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ClaimItemId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ClaimItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "ClaimItems");

            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "ClaimItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "ClaimItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_ClaimId",
                table: "ClaimItems",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimItems_CurrencyId",
                table: "ClaimItems",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_Claims_ClaimId",
                table: "ClaimItems",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimItems_Currencies_CurrencyId",
                table: "ClaimItems",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
