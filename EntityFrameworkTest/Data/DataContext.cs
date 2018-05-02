using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Linq;

namespace EntityFrameworkTest.Data
{
    public class DataContext : DbContext
    {
        private ILogger logger;

        public DataContext(DbContextOptions<DataContext> options, ILogger _logger) : base(options)
        {
            logger = _logger;
            //Database.EnsureCreated();

            // This will create the DB if necessary
            Database.Migrate();
        }

        public DbSet<Models.Organization> Organizations { get; set; }
        public DbSet<Models.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            logger.Info("Setting model params");
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
       .Where(e => typeof(Common).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("Created")
                    .HasDefaultValue(new DateTime());

                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("Active")
                    .HasDefaultValue(true);

                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property("Modified")
                    .IsRequired(false);
            }
        }
    }
}
