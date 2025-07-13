using Evento.Core.Entities.Base;
using Evento.Core.Extensions;


/*
	File Auto Generated. This file is only generate once.

	DO NOT MODIFY ONLY THE FILE NAME AND ITS LOCATION
*/

namespace Evento.Core.Entities;

public class PESSOAS : PESSOAS_BASE
{
	public string NOME_CPF => $"{NOME} - {CPF.FormatarCpf()}";
}
