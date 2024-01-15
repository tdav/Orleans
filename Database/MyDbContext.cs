using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Toolbelt.ComponentModel.DataAnnotations;

#nullable disable

namespace Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<tbChargePoint> tbChargePoints { get; set; }
        public virtual DbSet<tbConnector> tbConnectors { get; set; }
        public virtual DbSet<tbConnectorStatus> tbConnectorStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<tbConnectorStatus>(entity => { entity.HasKey(e => new { e.ChargePointId, e.ConnectorId }); });

            modelBuilder.BuildIndexesFromAnnotations();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbConnection GetDbConnection()
        {
            return Database.GetDbConnection();
        }
    }
}