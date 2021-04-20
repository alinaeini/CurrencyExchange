using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Data.Migrations
{
    public partial class updatePiaddCommodityCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 20, 13, 19, 52, 462, DateTimeKind.Local).AddTicks(3156), new DateTime(2021, 4, 20, 13, 19, 52, 466, DateTimeKind.Local).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 20, 13, 19, 52, 466, DateTimeKind.Local).AddTicks(9823), new DateTime(2021, 4, 20, 13, 19, 52, 466, DateTimeKind.Local).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 20, 13, 19, 52, 469, DateTimeKind.Local).AddTicks(9175), new DateTime(2021, 4, 20, 13, 19, 52, 469, DateTimeKind.Local).AddTicks(9251) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 20, 13, 19, 52, 469, DateTimeKind.Local).AddTicks(9661), new DateTime(2021, 4, 20, 13, 19, 52, 469, DateTimeKind.Local).AddTicks(9684) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 17, 14, 19, 27, 633, DateTimeKind.Local).AddTicks(1063), new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(3541) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(6554), new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(6602) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(606), new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(659) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(979), new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(993) });
        }
    }
}
