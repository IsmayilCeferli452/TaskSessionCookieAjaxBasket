using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloAsp.Migrations
{
    public partial class AddedRowToFooterSocialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Socials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9664));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Socials");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 22, 5, 6, 11, 658, DateTimeKind.Local).AddTicks(651));
        }
    }
}
