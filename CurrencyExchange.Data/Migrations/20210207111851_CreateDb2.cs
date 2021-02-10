using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class CreateDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 158, DateTimeKind.Local).AddTicks(5946), new DateTime(2021, 2, 7, 14, 45, 23, 162, DateTimeKind.Local).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 163, DateTimeKind.Local).AddTicks(373), new DateTime(2021, 2, 7, 14, 45, 23, 163, DateTimeKind.Local).AddTicks(414) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(8986), new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9087), new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9094) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9108), new DateTime(2021, 2, 7, 14, 45, 23, 164, DateTimeKind.Local).AddTicks(9112) });
        }
    }
}
