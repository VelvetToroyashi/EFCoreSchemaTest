using EFCoreTests;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1;

public class ForeignContext : DbContext
{
    public DbSet<ForeignEntity> ForeignEntities => Set<ForeignEntity>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=kobalt;Username=kobalt;Password=kobalt;");
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("foreign");
    }
}

public class ForeignEntity
{
    public int Id { get; set; }
    
    public string Thing { get; set; }
    
    public int CoreEntityId { get; set; }
    public CoreEntity CoreEntity { get; set; }
}