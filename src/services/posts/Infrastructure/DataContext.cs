using AppCommon.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PostsApi.Infrastructure;

class DataContext(DbContextOptions options) : DbContext(options), IDataContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    async Task IDataContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}