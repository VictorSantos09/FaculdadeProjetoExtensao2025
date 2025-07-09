using Evento.Shared.Types;

namespace Evento.Services.Evento.Cadastro;

public interface IEventoCadastroService
{
    Task<IFinal> CadastrarAsync(EventoCadastroDTO dto);
}
