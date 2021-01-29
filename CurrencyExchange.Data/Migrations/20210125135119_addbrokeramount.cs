using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Data.Migrations
{
    public partial class addbrokeramount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AmountBalanceBroker",
                table: "Brokers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 368, DateTimeKind.Local).AddTicks(6594), new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(7959), new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(8008) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9579), new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9708), new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9724), new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9735), new DateTime(2021, 1, 25, 17, 21, 18, 375, DateTimeKind.Local).AddTicks(9740) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountBalanceBroker",
                table: "Brokers");

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 324, DateTimeKind.Local).AddTicks(216), new DateTime(2021, 1, 24, 14, 15, 33, 328, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 329, DateTimeKind.Local).AddTicks(1197), new DateTime(2021, 1, 24, 14, 15, 33, 329, DateTimeKind.Local).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1187), new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1292), new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1306), new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1314), new DateTime(2021, 1, 24, 14, 15, 33, 331, DateTimeKind.Local).AddTicks(1318) });
        }
    }
}
