using System.Data;
using Evento.Core.Entities.Enums;

namespace Evento.Core.Repositories.Base.Shared;

public interface IREPOSITORY
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    Task<bool> ExistsAsync<TKey>(TABLE table, TKey id, CancellationToken cancellationToken = default);
    Task<bool> IfCountOneAsync(string sql, object args, CancellationToken cancellationToken = default);
    Task<bool> IfAsync(string sql, object args, CancellationToken cancellationToken = default);
}
