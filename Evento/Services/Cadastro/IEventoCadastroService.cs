using Evento.Shared.Types;

namespace Evento.Services.Cadastro;

public interface IEventoCadastroService
{
    Task<IFinal> CadastrarAsync(EventoCadastroDTO dto);
}
