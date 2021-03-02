using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class AddComany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 23, 37, 677, DateTimeKind.Local).AddTicks(1184), new DateTime(2021, 3, 2, 9, 23, 37, 681, DateTimeKind.Local).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 23, 37, 681, DateTimeKind.Local).AddTicks(3828), new DateTime(2021, 3, 2, 9, 23, 37, 681, DateTimeKind.Local).AddTicks(3871) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 23, 37, 683, DateTimeKind.Local).AddTicks(2976), new DateTime(2021, 3, 2, 9, 23, 37, 683, DateTimeKind.Local).AddTicks(3005) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 23, 37, 683, DateTimeKind.Local).AddTicks(3262), new DateTime(2021, 3, 2, 9, 23, 37, 683, DateTimeKind.Local).AddTicks(3272) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 22, 40, 691, DateTimeKind.Local).AddTicks(1615), new DateTime(2021, 3, 2, 9, 22, 40, 695, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 22, 40, 695, DateTimeKind.Local).AddTicks(6307), new DateTime(2021, 3, 2, 9, 22, 40, 695, DateTimeKind.Local).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 22, 40, 697, DateTimeKind.Local).AddTicks(7466), new DateTime(2021, 3, 2, 9, 22, 40, 697, DateTimeKind.Local).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 22, 40, 697, DateTimeKind.Local).AddTicks(7782), new DateTime(2021, 3, 2, 9, 22, 40, 697, DateTimeKind.Local).AddTicks(7793) });
        }
    }
}
