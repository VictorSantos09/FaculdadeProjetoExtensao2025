using Dapper;
using Evento.Core.Entities;
using Evento.Core.Repositories.Base;
using Evento.Core.Repositories.Interfaces;
using System.Data;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Core.Repositories;

public class EVENTOS_PESSOAS_REPOSITORY : EVENTOS_PESSOAS_REPOSITORY_BASE<EVENTOS_PESSOAS>, IEVENTOS_PESSOAS_REPOSITORY
{
    public EVENTOS_PESSOAS_REPOSITORY(IDbConnection connection) : base(connection)
    {
    }

    public async Task<EVENTOS_PESSOAS?> GetByEventoPessoaAsync(int idPessoa, int idEvento)
    {
        var sql = $"SELECT * FROM eventos_pessoas WHERE ID_EVENTO = @idEvento and ID_PESSOA = @idPessoa";
        return await _connection.QuerySingleOrDefaultAsync<EVENTOS_PESSOAS>(sql, new { idEvento, idPessoa });
    }

    public async Task<IEnumerable<PESSOAS>> GetPessoaByEventoAsync(int idEvento)
    {
        var sql = @$"select p.*, ep.DATA_CONFIRMACAO from pessoas p
                    join eventos_pessoas ep on ep.ID_PESSOA = p.ID
                    where ep.ID_EVENTO = @idEvento";
        return await _connection.QueryAsync<PESSOAS>(sql, new { idEvento});
    }

    public async Task<IEnumerable<PESSOAS>> GetPessoaForaEventosAsync(int idEvento)
    {
        var sql = @$"SELECT p.*
                    FROM pessoas p
                    LEFT JOIN eventos_pessoas ep ON ep.ID_PESSOA = p.ID AND ep.ID_EVENTO = @idEvento
                    WHERE ep.ID_PESSOA IS NULL";
        return await _connection.QueryAsync<PESSOAS>(sql, new { idEvento });
    }

    public async Task<int> DeleteAsync(int idEvento, int idPessoa)
    {
        var sql = $"DELETE FROM eventos_pessoas WHERE ID_EVENTO = @idEvento AND ID_PESSOA = @idPessoa";
        return await _connection.ExecuteAsync(sql, new { idEvento, idPessoa });
    }

    public async Task<int> DeleteByIdEventoAsync(int idEvento)
    {
        var sql = $"DELETE FROM eventos_pessoas WHERE ID_EVENTO = @idEvento";
        return await _connection.ExecuteAsync(sql, new { idEvento });
    }
}
