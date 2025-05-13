using System.Data;
using Dapper;
using Evento.Entities.Enums;


namespace Evento.Repositories.Base.Shared;

public abstract class REPOSITORY : IREPOSITORY
{
    private protected readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    protected REPOSITORY(IDbConnection conn)
    {
        _connection = conn;
    }

    public void BeginTransaction()
    {
        Open();
        _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
        Close();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        Close();
    }

    public async Task<bool> ExistsAsync<TKey>(TABLE table, TKey id, CancellationToken cancellationToken = default)
    {
        return await IfCountOneAsync($"{table} WHERE ID = @Id", new { id }, cancellationToken);
    }

    public async Task<bool> IfCountOneAsync(string sql, object? args = null, CancellationToken cancellationToken = default)
    {
        var innerSql = @$"SELECT IF((SELECT COUNT(1) FROM {sql}), true, false) AS RESULT";

        CommandDefinition command = new(innerSql, args, cancellationToken: cancellationToken);

        return await _connection.ExecuteScalarAsync<bool>(command);
    }

    public async Task<bool> IfAsync(string sql, object args, CancellationToken cancellationToken = default)
    {
        var innerSql = @$"SELECT IF(({sql}), true, false) AS RESULT";

        CommandDefinition command = new(innerSql, args, cancellationToken: cancellationToken);

        return await _connection.ExecuteScalarAsync<bool>(command);
    }

    private IDbConnection Open()
    {
        if (_connection is null || _connection?.State == ConnectionState.Closed)
        {
            _connection.Open();
        }
        return _connection;
    }

    private void Close()
    {
        _connection.Close();
    }
}
