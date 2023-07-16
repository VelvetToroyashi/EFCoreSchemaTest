using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreTests;

public class IDesignTimeCoreContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
{
    public CoreDbContext CreateDbContext(string[] args) => new CoreDbContext();
    
}