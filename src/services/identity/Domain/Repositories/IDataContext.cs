namespace IdentityApi.Domain.Repositories;

public interface IDataContext
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}