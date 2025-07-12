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
}
