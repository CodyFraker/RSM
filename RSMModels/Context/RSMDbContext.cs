using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RSMModels.Models.Brewery;
using RSMModels.Models.City;
using RSMModels.Models.Country;
using RSMModels.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RSMModels.Context
{
    public class RSMDbContext : DbContext
    {
        public RSMDbContext(DbContextOptions<RSMDbContext> options) : base(options)
        { }

        public static string ConnectionString => $"Host={Environment.GetEnvironmentVariable("DB_HOST")};"
            + $"Port={Environment.GetEnvironmentVariable("DB_PORT")};"
            + $"Username={Environment.GetEnvironmentVariable("DB_USER")};"
            + $"Password={Environment.GetEnvironmentVariable("DB_PASS")};"
            + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
            + $"SSL Mode=none";

        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
            };

            modelBuilder.Entity<Brewery>()
                .Property(s => s.Type)
                .HasConversion(new EnumToStringConverter<Models.Brewery.Type>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
