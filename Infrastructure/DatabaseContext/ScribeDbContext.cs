using Microsoft.EntityFrameworkCore;
using Scribe.Api.Infrastructure.Models;
namespace Scribe.Api.Infrastructure.DatabaseContext;

public class ScribeDbContext : DbContext
{
    public ScribeDbContext(DbContextOptions<ScribeDbContext> options) : base(options) { }

    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(u => u.Id);
            //entity.Property(u => u.Title).IsRequired().HasMaxLength(100);
            //entity.Property(u => u.Description).HasMaxLength(100);
        });
    }
}
