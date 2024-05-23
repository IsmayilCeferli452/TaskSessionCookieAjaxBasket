using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloAsp.Migrations
{
    public partial class EditedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 50, 12, 941, DateTimeKind.Local).AddTicks(5109));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 16, 4, 46, 29, 429, DateTimeKind.Local).AddTicks(6346));
        }
    }
}
