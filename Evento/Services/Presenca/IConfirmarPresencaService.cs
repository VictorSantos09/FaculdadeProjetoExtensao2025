using Evento.Shared.Types;

namespace Evento.Services.Presenca;
public interface IConfirmarPresencaService
{
    Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto);
}