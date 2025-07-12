using Dapper;
using System.Data;
using Evento.Core.Repositories.Base.Shared;
using Evento.Core.Entities.Base;
using Evento.Core.Repositories.Base.Interfaces;

/*
    File Auto Generated. DO NOT MODIFY.
*/

namespace Evento.Core.Repositories.Base;

public abstract class PESSOAS_REPOSITORY_BASE<T> : REPOSITORY, IPESSOAS_REPOSITORY_BASE<T> where T : PESSOAS_BASE
{
    public PESSOAS_REPOSITORY_BASE(IDbConnection connection) : base(connection)
    {
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = $"SELECT * FROM pessoas";
        return await _connection.QueryAsync<T>(sql);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM pessoas WHERE ID = @id";
        return await _connection.QuerySingleOrDefaultAsync<T>(sql, new { id });
    }

    public virtual async Task AddAsync(T parameters)
    {
        var sql = @"INSERT INTO pessoas (
                                ID,
                                NOME,
                                DATA_NASCIMENTO,
                                CPF,
                                EMAIL,
                                CREATED_AT,
                                UPDATED_AT
                                ) 
                                VALUES (
                                @ID,
                                @NOME,
                                @DATA_NASCIMENTO,
                                @CPF,
                                @EMAIL,
                                @CREATED_AT,
                                @UPDATED_AT
                                )";
    
        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task UpdateAsync(int id, T parameters)
    {
        var sql = @"UPDATE pessoas SET
        ID = @ID,
        NOME = @NOME,
        DATA_NASCIMENTO = @DATA_NASCIMENTO,
        CPF = @CPF,
        EMAIL = @EMAIL,
        CREATED_AT = @CREATED_AT,
        UPDATED_AT = @UPDATED_AT
        WHERE ID = @id";

        await _connection.ExecuteAsync(sql, parameters);
    }

    public virtual async Task<int> DeleteAsync(int id)
    {
        var sql = $"DELETE FROM pessoas WHERE ID = @id";
        return await _connection.ExecuteAsync(sql, new { id });
    }
}