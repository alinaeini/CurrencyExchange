using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class CreateDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 548, DateTimeKind.Local).AddTicks(5023), new DateTime(2021, 2, 7, 14, 50, 54, 552, DateTimeKind.Local).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 552, DateTimeKind.Local).AddTicks(5039), new DateTime(2021, 2, 7, 14, 50, 54, 552, DateTimeKind.Local).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6063), new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6175), new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6188), new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6192) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6198), new DateTime(2021, 2, 7, 14, 50, 54, 554, DateTimeKind.Local).AddTicks(6202) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 562, DateTimeKind.Local).AddTicks(1121), new DateTime(2021, 2, 7, 14, 48, 50, 566, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 566, DateTimeKind.Local).AddTicks(4157), new DateTime(2021, 2, 7, 14, 48, 50, 566, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5339), new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5473), new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5487), new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5495), new DateTime(2021, 2, 7, 14, 48, 50, 568, DateTimeKind.Local).AddTicks(5499) });
        }
    }
}
