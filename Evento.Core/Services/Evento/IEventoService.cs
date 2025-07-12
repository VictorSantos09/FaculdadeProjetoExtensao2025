using Evento.Core.Entities;
using Evento.Core.Services.Evento.DTO;
using Evento.Core.Shared.Types;

namespace Evento.Core.Services.Evento;
public interface IEventoService
{
    Task<IFinal> CadastrarAsync(EVENTOS dto);
    Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(EVENTOS evento);
}