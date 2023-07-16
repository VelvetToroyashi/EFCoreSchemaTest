using Microsoft.EntityFrameworkCore.Design;

namespace ClassLibrary1;

public class IDesignTimeForeignContextFactory : IDesignTimeDbContextFactory<ForeignContext>
{
    public ForeignContext CreateDbContext(string[] args) => new ForeignContext();
    
}