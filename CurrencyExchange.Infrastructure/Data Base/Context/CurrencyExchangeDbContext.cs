using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.EntityModels.Broker;
using CurrencyExchange.Domain.EntityModels.Company;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.EntityModels.ExchangeDeclaration;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Context
{
    public class CurrencyExchangeDbContext : DbContext
    {
        #region Constructor
        public CurrencyExchangeDbContext(DbContextOptions<CurrencyExchangeDbContext> options) : base(options)
        {

        }

        #endregion

        #region Db Sets

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<PeroformaInvoice> PeroformaInvoices { get; set; } 
        public DbSet<PeroformaInvoiceDetail> PeroformaInvoiceDetails { get; set; }
        public DbSet<ExDeclaration> ExDeclarations { get; set; }
        public DbSet<CurrencySale> CurrencySales { get; set; }
        public DbSet<CurrencySaleDetailPi> CurrencySaleDetailPis { get; set; }
        public DbSet<CurrencySaleDetailExDec> CurrencySaleDetailExDecs { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }

        #endregion

        #region OnModelCreating 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Disable Cascading Delete

            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fkCascade in cascades)
            {
                fkCascade.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion

            #region Broker Entity

            modelBuilder.Entity<Broker>().Property(e => e.ServiceChargeCash).HasPrecision(6, 3);
            modelBuilder.Entity<Broker>().Property(e => e.ServiceChargeAccount).HasPrecision(6, 3);
            
            #endregion

            #region Seed Data Broker(s)

            var brokers = new List<Broker>()
            {
                new Broker()
                {
                    Id = 1,
                    Name = "شرکت تضامنی علی نائیج حقیقی و شرکا",
                    Title = "صرافی اریکه",
                    Description = "ندارد",
                    Tel = "ندارد",
                    Address = "ندارد",
                    IsDelete = false,
                    IsActive = true,
                    CreateDate = DateTime.Now ,
                    LastUpdateDate = DateTime.Now,
                    ServiceChargeAccount = 3/1000,
                    ServiceChargeCash = 3/1000
                },
                new Broker()
                {
                    Id = 2,
                    Name = "شرکت تضامنی محمد رستمی و شرکا",
                    Title = "صرافی نماد",
                    Description = "ندارد",
                    Tel = "ندارد",
                    Address = "ندارد",
                    IsDelete = false,
                    IsActive = true,
                    CreateDate = DateTime.Now ,
                    LastUpdateDate = DateTime.Now,
                    ServiceChargeAccount =3/1000,
                    ServiceChargeCash = 3/1000
                }


            };
            modelBuilder.Entity<Broker>().HasData(brokers);
            #endregion

            #region Seed Data Roles(s)

            var adminRole = new Role()
            {
                Id = 1,
                Name = "Admin",
                Title = "راهبر سیستم",
                IsDelete = false,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };
            var roles = new List<Role>()
            {
                adminRole,
                new Role()
                {
                    Id = 2,
                    Name = "User",
                    Title = "کاربر",
                    IsDelete = false,
                    CreateDate = DateTime.Now ,
                    LastUpdateDate = DateTime.Now,
                }

            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

        }

        #endregion
    }
}
