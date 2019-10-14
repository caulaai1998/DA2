using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCoreApp.Data.EF.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NamePublisher",
                table: "Publishers",
                newName: "PublisherName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Publishers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Publishers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HomeFlag",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeOrder",
                table: "Publishers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "HomeFlag",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "HomeOrder",
                table: "Publishers");

            migrationBuilder.RenameColumn(
                name: "PublisherName",
                table: "Publishers",
                newName: "NamePublisher");
        }
    }
}
