using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Migrations
{
    public partial class CreateDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolePermissions_MenuItems_MenuItemId",
                table: "UserRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "Permissions");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "UserRolePermissions",
                newName: "PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolePermissions_MenuItemId",
                table: "UserRolePermissions",
                newName: "IX_UserRolePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_ParentId",
                table: "Permissions",
                newName: "IX_Permissions_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 6, DateTimeKind.Local).AddTicks(4978), new DateTime(2021, 2, 7, 14, 52, 13, 10, DateTimeKind.Local).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 11, DateTimeKind.Local).AddTicks(351), new DateTime(2021, 2, 7, 14, 52, 13, 11, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1398), new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1432) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1522), new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1536), new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreateDate", "LastUpdateDate" },
                values: new object[] { new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1546), new DateTime(2021, 2, 7, 14, 52, 13, 13, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolePermissions_Permissions_PermissionId",
                table: "UserRolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolePermissions_Permissions_PermissionId",
                table: "UserRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "UserRolePermissions",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolePermissions_PermissionId",
                table: "UserRolePermissions",
                newName: "IX_UserRolePermissions_MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_ParentId",
                table: "MenuItems",
                newName: "IX_MenuItems_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolePermissions_MenuItems_MenuItemId",
                table: "UserRolePermissions",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
