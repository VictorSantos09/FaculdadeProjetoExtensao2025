using Evento.Core.Shared.Types;

namespace Evento.Core.Services.Evento.Cadastro;

public interface IEventoCadastroService
{
    Task<IFinal> CadastrarAsync(EventoCadastroDTO dto);
}
