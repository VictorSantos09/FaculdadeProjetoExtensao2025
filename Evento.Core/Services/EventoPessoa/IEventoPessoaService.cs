using Evento.Core.Entities;

namespace Evento.Core.Services.EventoPessoa;
public interface IEventoPessoaService
{
    Task CreateAsync(EVENTOS_PESSOAS eventoPessoa);
    Task DeleteAsync(int id);
    Task<IEnumerable<EVENTOS_PESSOAS>> GetAllAsync();
    Task<IEnumerable<PESSOAS>> GetPessoaByEventoAsync(int eventoId);
    Task<EVENTOS_PESSOAS?> GetByIdAsync(int id);
    Task UpdateAsync(EVENTOS_PESSOAS eventoPessoa);
    Task<IEnumerable<PESSOAS>> GetPessoaForaEventosAsync(int eventoId);
    Task AdicionarParticipantesAsync(IEnumerable<int> idsPessoas, int eventoId);
    Task DeleteAsync(int idEvento, int idPessoa);
}