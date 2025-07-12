using System.Data;
using Evento.Core.Entities;
using Evento.Core.Repositories.Base;
using Evento.Core.Repositories.Interfaces;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Core.Repositories;

public class EVENTOS_REPOSITORY : EVENTOS_REPOSITORY_BASE<EVENTOS>, IEVENTOS_REPOSITORY
{
	public EVENTOS_REPOSITORY(IDbConnection connection) : base(connection)
	{
	}
}
