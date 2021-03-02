﻿// <auto-generated />
using System;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyExchange.Infrastructure.Migrations
{
    [DbContext(typeof(CurrencyExchangeDbContext))]
    [Migration("20210302055527_AddComany4")]
    partial class AddComany4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AccessLink")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("PersianName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateDate = new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(724),
                            IsDelete = false,
                            LastUpdateDate = new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(798),
                            Name = "Admin",
                            Title = "راهبر سیستم"
                        },
                        new
                        {
                            Id = 2L,
                            CreateDate = new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(1150),
                            IsDelete = false,
                            LastUpdateDate = new DateTime(2021, 3, 2, 9, 25, 26, 727, DateTimeKind.Local).AddTicks(1162),
                            Name = "User",
                            Title = "کاربر"
                        });
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.UserRolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserRoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserRolePermissions");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Account.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmailActiveCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActivated")
                        .HasMaxLength(100)
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Broker.Broker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long?>("AmountBalanceBroker")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(500)
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ServiceChargeAccount")
                        .HasPrecision(6, 3)
                        .HasColumnType("decimal(6,3)");

                    b.Property<decimal>("ServiceChargeCash")
                        .HasPrecision(6, 3)
                        .HasColumnType("decimal(6,3)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brokers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "ندارد",
                            CreateDate = new DateTime(2021, 3, 2, 9, 25, 26, 719, DateTimeKind.Local).AddTicks(3569),
                            Description = "ندارد",
                            IsActive = true,
                            IsDelete = false,
                            LastUpdateDate = new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(5632),
                            Name = "شرکت تضامنی علی نائیج حقیقی و شرکا",
                            ServiceChargeAccount = 0m,
                            ServiceChargeCash = 0m,
                            Tel = "ندارد",
                            Title = "صرافی اریکه"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "ندارد",
                            CreateDate = new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(8747),
                            Description = "ندارد",
                            IsActive = true,
                            IsDelete = false,
                            LastUpdateDate = new DateTime(2021, 3, 2, 9, 25, 26, 724, DateTimeKind.Local).AddTicks(8792),
                            Name = "شرکت تضامنی محمد رستمی و شرکا",
                            ServiceChargeAccount = 0m,
                            ServiceChargeCash = 0m,
                            Tel = "ندارد",
                            Title = "صرافی نماد"
                        });
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Company.CompanyInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tel")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WebSite")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CompanyInfo");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Customers.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.ExchangeDeclaration.ExDeclaration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExchangeDeclarationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExprireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("Qty")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ExDeclarations");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BasePrice")
                        .HasMaxLength(100)
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PiCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PiDate")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<long>("TotalPrice")
                        .HasMaxLength(100)
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("PeroformaInvoices");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoiceDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BrokerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("DepositPrice")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PeroformaInvoiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("PeroformaInvoiceId");

                    b.ToTable("PeroformaInvoiceDetails");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BrokerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaleDate")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<long>("SalePrice")
                        .HasColumnType("bigint");

                    b.Property<long>("SalePricePerUnit")
                        .HasColumnType("bigint");

                    b.Property<long>("TransferPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("TransferType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CurrencySales");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySaleDetailExDec", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CurrencySaleId")
                        .HasColumnType("bigint");

                    b.Property<long>("ExDeclarationId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrencySaleId");

                    b.HasIndex("ExDeclarationId");

                    b.ToTable("CurrencySaleDetailExDecs");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySaleDetailPi", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CurrencySaleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PeroformaInvoiceDetailId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfitLossAmount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrencySaleId");

                    b.HasIndex("PeroformaInvoiceDetailId");

                    b.ToTable("CurrencySaleDetailPis");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.Permission", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Access.Permission", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.UserRole", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Access.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.Account.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.UserRolePermission", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Access.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.Access.UserRole", "UserRole")
                        .WithMany("UserRolePermissions")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoiceDetail", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Broker.Broker", "Broker")
                        .WithMany("PeroformaInvoiceDetails")
                        .HasForeignKey("BrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoice", "PeroformaInvoice")
                        .WithMany("PeroformaInvoiceDetails")
                        .HasForeignKey("PeroformaInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Broker");

                    b.Navigation("PeroformaInvoice");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySale", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Broker.Broker", "Broker")
                        .WithMany("CurrencySales")
                        .HasForeignKey("BrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.Customers.Customer", "Customer")
                        .WithMany("CurrencySale")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Broker");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySaleDetailExDec", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Sales.CurrencySale", "CurrencySale")
                        .WithMany("CurrencySaleDetailExDecs")
                        .HasForeignKey("CurrencySaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.ExchangeDeclaration.ExDeclaration", "ExDeclaration")
                        .WithMany("CurrencySaleDetailExDecs")
                        .HasForeignKey("ExDeclarationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencySale");

                    b.Navigation("ExDeclaration");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySaleDetailPi", b =>
                {
                    b.HasOne("CurrencyExchange.Domain.EntityModels.Sales.CurrencySale", "CurrencySale")
                        .WithMany("CurrencySaleDetailPies")
                        .HasForeignKey("CurrencySaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoiceDetail", "PeroformaInvoiceDetails")
                        .WithMany("CurrencySaleDetailPi")
                        .HasForeignKey("PeroformaInvoiceDetailId");

                    b.Navigation("CurrencySale");

                    b.Navigation("PeroformaInvoiceDetails");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Access.UserRole", b =>
                {
                    b.Navigation("UserRolePermissions");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Account.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Broker.Broker", b =>
                {
                    b.Navigation("CurrencySales");

                    b.Navigation("PeroformaInvoiceDetails");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Customers.Customer", b =>
                {
                    b.Navigation("CurrencySale");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.ExchangeDeclaration.ExDeclaration", b =>
                {
                    b.Navigation("CurrencySaleDetailExDecs");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoice", b =>
                {
                    b.Navigation("PeroformaInvoiceDetails");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.PeroformaInvoices.PeroformaInvoiceDetail", b =>
                {
                    b.Navigation("CurrencySaleDetailPi");
                });

            modelBuilder.Entity("CurrencyExchange.Domain.EntityModels.Sales.CurrencySale", b =>
                {
                    b.Navigation("CurrencySaleDetailExDecs");

                    b.Navigation("CurrencySaleDetailPies");
                });
#pragma warning restore 612, 618
        }
    }
}
