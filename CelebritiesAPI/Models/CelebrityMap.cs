using Microsoft.EntityFrameworkCore;
using CelebritiesAPI.Core.EntityLayer;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebritiesAPI.Models
{
  public static class CelebrityMap
  {
    public static ModelBuilder MapCelebrity(this ModelBuilder modelBuilder)
    {
      var entity = modelBuilder.Entity<Celebrity>();

      entity.ToTable("Celebrities");

      entity.HasKey(p => new { p.ID });

      entity.Property(p => p.ID).UseSqlServerIdentityColumn();

      return modelBuilder;
    }
  }
}
