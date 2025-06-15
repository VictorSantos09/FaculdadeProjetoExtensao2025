using Evento.Repositories.Base.Interfaces;
using Evento.Entities;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Repositories.Interfaces;

public interface IEVENTOS_PESSOAS_REPOSITORY : IEVENTOS_PESSOAS_REPOSITORY_BASE<EVENTOS_PESSOAS>
{
    Task<EVENTOS_PESSOAS?> GetByEventoPessoaAsync(int idPessoa, int idEvento);
}
