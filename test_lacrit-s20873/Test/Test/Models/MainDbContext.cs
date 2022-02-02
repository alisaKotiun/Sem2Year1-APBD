using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test.Configurations;
using Test.Services;

namespace Test.Models
{
    public interface IMainDbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);



    }
    public class MainDbContext : DbContext, IMainDbContext
    {
        private IConfiguration _configuration;

        public MainDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MainDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductionDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FirefighterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckActionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterActionEntityConfiguration());

            modelBuilder.Seed();
        }
    }
}
