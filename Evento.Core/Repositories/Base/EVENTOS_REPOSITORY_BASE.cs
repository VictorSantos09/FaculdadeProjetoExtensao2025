using Dapper;
using System.Data;
using Evento.Core.Repositories.Base.Shared;
using Evento.Core.Entities.Base;
using Evento.Core.Repositories.Base.Interfaces;

/*
    File Auto Generated. DO NOT MODIFY.
*/

namespace Evento.Core.Repositories.Base;

public abstract class EVENTOS_REPOSITORY_BASE<T> : REPOSITORY, IEVENTOS_REPOSITORY_BASE<T> where T : EVENTOS_BASE
{
    public EVENTOS_REPOSITORY_BASE(IDbConnection connection) : base(connection)
    {
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = $"SELECT * FROM eventos";
        return await _connection.QueryAsync<T>(sql);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM eventos WHERE ID = @id";
        return await _connection.QuerySingleOrDefaultAsync<T>(sql, new { id });
    }

    public virtual async Task AddAsync(T parameters)
    {
        var sql = @"INSERT INTO eventos (
                                ID,
                                NOME,
                                DESCRICAO,
                                OBSERVACAO,
                                DATA_INICIO,
                                DATA_FIM,
                                CAMINHO_QR_CODE,
                                CREATED_AT,
                                UPDATED_AT
                                ) 
                                VALUES (
                                @ID,
                                @NOME,
                                @DESCRICAO,
                                @OBSERVACAO,
                                @DATA_INICIO,
                                @DATA_FIM,
                                @CAMINHO_QR_CODE,
                                @CREATED_AT,
                                @UPDATED_AT
                                )";
    
        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task UpdateAsync(int id, T parameters)
    {
        var sql = @"UPDATE eventos SET
        ID = @ID,
        NOME = @NOME,
        DESCRICAO = @DESCRICAO,
        OBSERVACAO = @OBSERVACAO,
        DATA_INICIO = @DATA_INICIO,
        DATA_FIM = @DATA_FIM,
        CAMINHO_QR_CODE = @CAMINHO_QR_CODE,
        CREATED_AT = @CREATED_AT,
        UPDATED_AT = @UPDATED_AT
        WHERE ID = @id";

        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task<int> DeleteAsync(int id)
    {
        var sql = $"DELETE FROM eventos WHERE ID = @id";
        return await _connection.ExecuteAsync(sql, new { id });
    }
}