using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CelebritiesAPI.Models
{
    public class CelebritesDbContext : DbContext
    {
    public CelebritesDbContext(IOptions<AppSettings> appSettings)
    {
      ConnectionString = appSettings.Value.ConnectionString;
    }

    public String ConnectionString { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(ConnectionString);

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.MapCelebrity();

      base.OnModelCreating(modelBuilder);
    }
  }
}
