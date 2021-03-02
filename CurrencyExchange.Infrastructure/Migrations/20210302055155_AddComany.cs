using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class AddComany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 21, 54, 869, DateTimeKind.Local).AddTicks(4720), new DateTime(2021, 3, 2, 9, 21, 54, 873, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 21, 54, 873, DateTimeKind.Local).AddTicks(8711), new DateTime(2021, 3, 2, 9, 21, 54, 873, DateTimeKind.Local).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 21, 54, 875, DateTimeKind.Local).AddTicks(9624), new DateTime(2021, 3, 2, 9, 21, 54, 875, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 21, 54, 875, DateTimeKind.Local).AddTicks(9952), new DateTime(2021, 3, 2, 9, 21, 54, 875, DateTimeKind.Local).AddTicks(9964) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 19, 8, 321, DateTimeKind.Local).AddTicks(336), new DateTime(2021, 3, 2, 9, 19, 8, 325, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 19, 8, 325, DateTimeKind.Local).AddTicks(4715), new DateTime(2021, 3, 2, 9, 19, 8, 325, DateTimeKind.Local).AddTicks(4752) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 19, 8, 327, DateTimeKind.Local).AddTicks(3846), new DateTime(2021, 3, 2, 9, 19, 8, 327, DateTimeKind.Local).AddTicks(3873) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 19, 8, 327, DateTimeKind.Local).AddTicks(4143), new DateTime(2021, 3, 2, 9, 19, 8, 327, DateTimeKind.Local).AddTicks(4153) });
        }
    }
}
