using Evento.Core.Entities;
using Evento.Core.Repositories.Base.Interfaces;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Core.Repositories.Interfaces;

public interface IEVENTOS_PESSOAS_REPOSITORY : IEVENTOS_PESSOAS_REPOSITORY_BASE<EVENTOS_PESSOAS>
{
    Task<int> DeleteAsync(int idEvento, int idPessoa);
    Task<EVENTOS_PESSOAS?> GetByEventoPessoaAsync(int idPessoa, int idEvento);
    Task<IEnumerable<PESSOAS>> GetPessoaByEventoAsync(int idEvento);
    Task<IEnumerable<PESSOAS>> GetPessoaForaEventosAsync(int idEvento);
}
