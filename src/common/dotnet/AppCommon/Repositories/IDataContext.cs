namespace AppCommon.Repositories;

public interface IDataContext
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}