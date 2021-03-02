using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class AddComany4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "CompanyInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 25, 26, 719, DateTimeKind.Local).AddTicks(3569), new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(8747), new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(724), new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(1150), new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(1162) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "CompanyInfo");

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
    }
}
