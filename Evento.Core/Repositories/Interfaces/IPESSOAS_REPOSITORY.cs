using Evento.Core.Entities;
using Evento.Core.Repositories.Base.Interfaces;

/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Core.Repositories.Interfaces;

public interface IPESSOAS_REPOSITORY : IPESSOAS_REPOSITORY_BASE<PESSOAS>
{
    Task<PESSOAS?> GetByCPF(string cpf);
}
