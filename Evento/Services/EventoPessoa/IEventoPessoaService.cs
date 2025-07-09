using Evento.Entities;

namespace Evento.Services.EventoPessoa;
public interface IEventoPessoaService
{
    Task CreateAsync(EVENTOS_PESSOAS eventoPessoa);
    Task DeleteAsync(int id);
    Task<IEnumerable<EVENTOS_PESSOAS>> GetAllAsync();
    Task<IEnumerable<EVENTOS_PESSOAS>> GetByEventoIdAsync(int eventoId);
    Task<EVENTOS_PESSOAS?> GetByIdAsync(int id);
    Task<IEnumerable<EVENTOS_PESSOAS>> GetByPessoaIdAsync(int pessoaId);
    Task UpdateAsync(EVENTOS_PESSOAS eventoPessoa);
}