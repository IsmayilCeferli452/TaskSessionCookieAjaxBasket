using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloAsp.Migrations
{
    public partial class CreatedExpertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "CreateDate", "Image", "Role", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6538), "h3-team-img-1.png", "Florist", false, "CRYSTAL BROOKS" },
                    { 2, new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6540), "h3-team-img-2.png", "Manager", false, "SHIRLEY HARRIS" },
                    { 3, new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6541), "h3-team-img-3.png", "Florist", false, "BEVERLY CLARK" },
                    { 4, new DateTime(2024, 5, 15, 4, 9, 17, 466, DateTimeKind.Local).AddTicks(6541), "h3-team-img-4.png", "Florist", false, "AMANDA WATKINS" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 3, 36, 45, 124, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 3, 36, 45, 124, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 3, 36, 45, 124, DateTimeKind.Local).AddTicks(9050));
        }
    }
}
