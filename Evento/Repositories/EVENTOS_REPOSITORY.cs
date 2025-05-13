using System.Data;
using Evento.Repositories.Base;
using Evento.Repositories.Interfaces;
using Evento.Entities;

namespace Evento.Repositories;

public class EVENTOS_REPOSITORY : EVENTOS_REPOSITORY_BASE<EVENTOS>, IEVENTOS_REPOSITORY
{
	public EVENTOS_REPOSITORY(IDbConnection connection) : base(connection)
	{
	}
}
