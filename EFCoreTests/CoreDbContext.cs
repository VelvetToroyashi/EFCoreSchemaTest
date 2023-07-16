using Microsoft.EntityFrameworkCore;

namespace EFCoreTests;

public class CoreDbContext : DbContext
{
    public DbSet<CoreEntity> CoreEntities => Set<CoreEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=kobalt;Username=kobalt;Password=kobalt;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("core");
    }
}

public class CoreEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}