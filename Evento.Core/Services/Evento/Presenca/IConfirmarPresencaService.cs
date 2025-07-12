using Evento.Core.Shared.Types;

namespace Evento.Core.Services.Evento.Presenca;
public interface IConfirmarPresencaService
{
    Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto);
}