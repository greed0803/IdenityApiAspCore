using Data.Model;
using Data.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Context
{
    public class IdentityProviderContext : DbContext
    {
        private IdentityProviderContext() { }
        private static IdentityProviderContext? _instance;

        public static IdentityProviderContext GetContext()
        {
            _instance ??= new IdentityProviderContext();
            return _instance;
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(AppSettings.ConnectionString() ?? "");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("status_id");
                entity.Property(e => e.Desc).HasColumnName("status_desc");

            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("user_type_id");
                entity.Property(e => e.StatusId).HasColumnName("status_id");
                entity.Property(e => e.Desc).HasColumnName("user_type_desc");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("user_id");
                entity.Property(e => e.StatusId).HasColumnName("status_id");
                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
                entity.Property(e => e.UserName).HasColumnName("username");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Email).HasColumnName("email");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("client_id");
                entity.Property(e => e.FirstName).HasColumnName("client_first_name");
                entity.Property(e => e.LastName).HasColumnName("client_last_name");
                entity.Property(e => e.Email).HasColumnName("client_email");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.AgentUserId).HasColumnName("agent_user_id");
           
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("policy_id");
                entity.Property(e => e.PremiumAmount).HasColumnName("policy_premium_amount");
                entity.Property(e => e.PolicyStartDate).HasColumnName("policy_start_date");
                entity.Property(e => e.PolicyEndDate).HasColumnName("policy_end_date");
                entity.Property(e => e.CoverageType).HasColumnName("policy_coverage_type");
                entity.Property(e => e.ClientId).HasColumnName("client_id");
            });


        }
    }
}
