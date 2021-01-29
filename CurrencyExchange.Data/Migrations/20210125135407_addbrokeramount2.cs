using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Data.Migrations
{
    public partial class addbrokeramount2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AmountBalanceBroker",
                table: "Brokers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AmountBalanceBroker", "CreateDate", "LastUpdateDate" },
                values: new object[] { null, new DateTime(2021, 1, 25, 17, 24, 6, 927, DateTimeKind.Local).AddTicks(3196), new DateTime(2021, 1, 25, 17, 24, 6, 933, DateTimeKind.Local).AddTicks(4679) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AmountBalanceBroker", "CreateDate", "LastUpdateDate" },
                values: new object[] { null, new DateTime(2021, 1, 25, 17, 24, 6, 933, DateTimeKind.Local).AddTicks(7705), new DateTime(2021, 1, 25, 17, 24, 6, 933, DateTimeKind.Local).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9327), new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9455), new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9471), new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9476) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9482), new DateTime(2021, 1, 25, 17, 24, 6, 935, DateTimeKind.Local).AddTicks(9487) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AmountBalanceBroker",
                table: "Brokers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AmountBalanceBroker", "CreateDate", "LastUpdateDate" },
                values: new object[] { 0L, new DateTime(2021, 1, 25, 17, 21, 18, 368, DateTimeKind.Local).AddTicks(6594), new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AmountBalanceBroker", "CreateDate", "LastUpdateDate" },
                values: new object[] { 0L, new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(7959), new DateTime(2021, 1, 25, 17, 21, 18, 373, DateTimeKind.Local).AddTicks(8008) });

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
    }
}
