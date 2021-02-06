using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaimManager.Infrastructure.Migrations.ApplicationDb
{
    public partial class claimitemidmanual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
