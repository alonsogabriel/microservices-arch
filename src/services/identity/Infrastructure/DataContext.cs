using AppCommon.Repositories;
using IdentityApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infrastructure;

class DataContext(DbContextOptions options) : DbContext(options), IDataContext
{
    public DbSet<User> Users { get; init; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<User>();
        user.ToTable(nameof(User));
        user.HasKey(e => e.Id);
        user.Property(e => e.Username).IsRequired().HasMaxLength(32);
        user.Property(e => e.Email).IsRequired().HasMaxLength(255);
        user.Property<string?>("PasswordHash").IsRequired(false).HasMaxLength(255);
        user.Property(e => e.PhoneNumber).IsRequired(false).HasMaxLength(40);
        user.Property(e => e.CreatedAt).IsRequired();
        user.Property(e => e.UpdatedAt).IsRequired(false);
        user.HasIndex(e => e.Username).IsUnique();
        user.HasIndex(e => e.Email).IsUnique();
    }
    Task IDataContext.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}