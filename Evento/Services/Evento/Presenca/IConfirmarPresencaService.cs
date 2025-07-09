using Evento.Shared.Types;

namespace Evento.Services.Evento.Presenca;
public interface IConfirmarPresencaService
{
    Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto);
}