using Dapper;
using System.Data;
using Evento.Entities.Base;
using Evento.Repositories.Base.Interfaces;
using Evento.Repositories.Base.Shared;

/*
    File Auto Generated. DO NOT MODIFY.
*/

namespace Evento.Repositories.Base;

public abstract class EVENTOS_PESSOAS_REPOSITORY_BASE<T> : REPOSITORY, IEVENTOS_PESSOAS_REPOSITORY_BASE<T> where T : EVENTOS_PESSOAS_BASE
{
    public EVENTOS_PESSOAS_REPOSITORY_BASE(IDbConnection connection) : base(connection)
    {
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = $"SELECT * FROM eventos_pessoas";
        return await _connection.QueryAsync<T>(sql);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM eventos_pessoas WHERE ID = @id";
        return await _connection.QuerySingleOrDefaultAsync<T>(sql, new { id });
    }

    public virtual async Task AddAsync(T parameters)
    {
        var sql = @"INSERT INTO eventos_pessoas (
                                ID,
                                ID_EVENTO,
                                ID_PESSOA,
                                DATA_CONFIRMACAO,
                                CREATED_AT,
                                UPDATED_AT
                                ) 
                                VALUES (
                                @ID,
                                @ID_EVENTO,
                                @ID_PESSOA,
                                @DATA_CONFIRMACAO,
                                @CREATED_AT,
                                @UPDATED_AT
                                )";
    
        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task UpdateAsync(int id, T parameters)
    {
        var sql = @"UPDATE eventos_pessoas SET
        ID = @ID,
        ID_EVENTO = @ID_EVENTO,
        ID_PESSOA = @ID_PESSOA,
        DATA_CONFIRMACAO = @DATA_CONFIRMACAO,
        CREATED_AT = @CREATED_AT,
        UPDATED_AT = @UPDATED_AT
        WHERE ID = @id";

        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task<int> DeleteAsync(int id)
    {
        var sql = $"DELETE FROM eventos_pessoas WHERE ID = @id";
        return await _connection.ExecuteAsync(sql, new { id });
    }
}