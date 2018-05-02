using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwningGroupID = table.Column<int>(nullable: true),
                    ProductGroupIDID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroup_OwningGroupID",
                        column: x => x.OwningGroupID,
                        principalTable: "ProductGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroup_ProductGroupIDID",
                        column: x => x.ProductGroupIDID,
                        principalTable: "ProductGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwningGroupID",
                table: "Products",
                column: "OwningGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupIDID",
                table: "Products",
                column: "ProductGroupIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductGroup");
        }
    }
}
