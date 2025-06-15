using Dapper;
using Evento.Entities;
using Evento.Repositories.Base;
using Evento.Repositories.Interfaces;
using System.Data;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Repositories;

public class PESSOAS_REPOSITORY : PESSOAS_REPOSITORY_BASE<PESSOAS>, IPESSOAS_REPOSITORY
{
	public PESSOAS_REPOSITORY(IDbConnection connection) : base(connection)
	{
	}

	public async Task<PESSOAS?> GetByCPF(string cpf)
	{
        var sql = $"SELECT * FROM pessoas WHERE CPF = @cpf";
        return await _connection.QuerySingleOrDefaultAsync<PESSOAS>(sql, new { cpf });
    }
}
