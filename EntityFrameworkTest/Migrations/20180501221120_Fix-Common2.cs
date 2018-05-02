using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.Migrations
{
    public partial class FixCommon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "organizationID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "organizationID",
                table: "ProductGroup",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_organizationID",
                table: "Products",
                column: "organizationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_organizationID",
                table: "ProductGroup",
                column: "organizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Organizations_organizationID",
                table: "ProductGroup",
                column: "organizationID",
                principalTable: "Organizations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Organizations_organizationID",
                table: "Products",
                column: "organizationID",
                principalTable: "Organizations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Organizations_organizationID",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Organizations_organizationID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_organizationID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_organizationID",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "organizationID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "organizationID",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organizations");
        }
    }
}
