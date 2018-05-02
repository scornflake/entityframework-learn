using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.Migrations
{
    public partial class FixCommon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Products",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Products",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "ProductGroup",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ProductGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ProductGroup",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Organizations",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Products",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Products",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Products",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "ProductGroup",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ProductGroup",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "ProductGroup",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
