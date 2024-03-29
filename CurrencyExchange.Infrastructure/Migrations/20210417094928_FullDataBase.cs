﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Infrastructure.Data.Migrations
{
    public partial class FullDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", maxLength: 500, nullable: false),
                    ServiceChargeAccount = table.Column<decimal>(type: "decimal(6,3)", precision: 6, scale: 3, nullable: false),
                    ServiceChargeCash = table.Column<decimal>(type: "decimal(6,3)", precision: 6, scale: 3, nullable: false),
                    AmountBalanceBroker = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommodityCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExDeclarations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeDeclarationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    ExprireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExDeclarations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiscellaneousCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscellaneousCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersianName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccessLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailActiveCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeroformaInvoices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PiDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    TotalPrice = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    BasePrice = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CommodityCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeroformaInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeroformaInvoices_CommodityCustomers_CommodityCustomerId",
                        column: x => x.CommodityCustomerId,
                        principalTable: "CommodityCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencySales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    SalePrice = table.Column<long>(type: "bigint", nullable: false),
                    SalePricePerUnit = table.Column<long>(type: "bigint", nullable: false),
                    TransferType = table.Column<int>(type: "int", nullable: false),
                    TransferPrice = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BrokerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencySales_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencySales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeroformaInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositPrice = table.Column<long>(type: "bigint", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    BrokerId = table.Column<long>(type: "bigint", nullable: false),
                    PeroformaInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeroformaInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeroformaInvoiceDetails_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeroformaInvoiceDetails_PeroformaInvoices_PeroformaInvoiceId",
                        column: x => x.PeroformaInvoiceId,
                        principalTable: "PeroformaInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencySaleDetailExDecs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ExDeclarationId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencySaleId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencySaleDetailExDecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencySaleDetailExDecs_CurrencySales_CurrencySaleId",
                        column: x => x.CurrencySaleId,
                        principalTable: "CurrencySales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencySaleDetailExDecs_ExDeclarations_ExDeclarationId",
                        column: x => x.ExDeclarationId,
                        principalTable: "ExDeclarations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencySaleDetailPis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ProfitLossAmount = table.Column<long>(type: "bigint", nullable: false),
                    CurrencySaleId = table.Column<long>(type: "bigint", nullable: false),
                    PeroformaInvoiceDetailId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencySaleDetailPis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencySaleDetailPis_CurrencySales_CurrencySaleId",
                        column: x => x.CurrencySaleId,
                        principalTable: "CurrencySales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencySaleDetailPis_PeroformaInvoiceDetails_PeroformaInvoiceDetailId",
                        column: x => x.PeroformaInvoiceDetailId,
                        principalTable: "PeroformaInvoiceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "Id", "Address", "AmountBalanceBroker", "CreateDate", "Description", "IsActive", "IsDelete", "LastUpdateDate", "Name", "ServiceChargeAccount", "ServiceChargeCash", "Tel", "Title" },
                values: new object[,]
                {
                    { 1L, "ندارد", null, new DateTime(2021, 4, 17, 14, 19, 27, 633, DateTimeKind.Local).AddTicks(1063), "ندارد", true, false, new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(3541), "شرکت تضامنی علی نائیج حقیقی و شرکا", 0m, 0m, "ندارد", "صرافی اریکه" },
                    { 2L, "ندارد", null, new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(6554), "ندارد", true, false, new DateTime(2021, 4, 17, 14, 19, 27, 637, DateTimeKind.Local).AddTicks(6602), "شرکت تضامنی محمد رستمی و شرکا", 0m, 0m, "ندارد", "صرافی نماد" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "LastUpdateDate", "Name", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(606), false, new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(659), "Admin", "راهبر سیستم" },
                    { 2L, new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(979), false, new DateTime(2021, 4, 17, 14, 19, 27, 640, DateTimeKind.Local).AddTicks(993), "User", "کاربر" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySaleDetailExDecs_CurrencySaleId",
                table: "CurrencySaleDetailExDecs",
                column: "CurrencySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySaleDetailExDecs_ExDeclarationId",
                table: "CurrencySaleDetailExDecs",
                column: "ExDeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySaleDetailPis_CurrencySaleId",
                table: "CurrencySaleDetailPis",
                column: "CurrencySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySaleDetailPis_PeroformaInvoiceDetailId",
                table: "CurrencySaleDetailPis",
                column: "PeroformaInvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySales_BrokerId",
                table: "CurrencySales",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencySales_CustomerId",
                table: "CurrencySales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PeroformaInvoiceDetails_BrokerId",
                table: "PeroformaInvoiceDetails",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_PeroformaInvoiceDetails_PeroformaInvoiceId",
                table: "PeroformaInvoiceDetails",
                column: "PeroformaInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PeroformaInvoices_CommodityCustomerId",
                table: "PeroformaInvoices",
                column: "CommodityCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_PermissionId",
                table: "UserRolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_UserRoleId",
                table: "UserRolePermissions",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "CurrencySaleDetailExDecs");

            migrationBuilder.DropTable(
                name: "CurrencySaleDetailPis");

            migrationBuilder.DropTable(
                name: "FinancialPeriods");

            migrationBuilder.DropTable(
                name: "MiscellaneousCustomers");

            migrationBuilder.DropTable(
                name: "UserRolePermissions");

            migrationBuilder.DropTable(
                name: "ExDeclarations");

            migrationBuilder.DropTable(
                name: "CurrencySales");

            migrationBuilder.DropTable(
                name: "PeroformaInvoiceDetails");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brokers");

            migrationBuilder.DropTable(
                name: "PeroformaInvoices");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CommodityCustomers");
        }
    }
}
