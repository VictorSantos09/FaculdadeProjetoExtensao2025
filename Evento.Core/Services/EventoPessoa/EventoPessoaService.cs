using Evento.Core.Entities;
using Evento.Core.Repositories.Interfaces;

namespace Evento.Core.Services.EventoPessoa;

public class EventoPessoaService(IEVENTOS_PESSOAS_REPOSITORY eventos_pessoas_repository) : IEventoPessoaService
{
    public async Task<IEnumerable<EVENTOS_PESSOAS>> GetAllAsync()
    {
        return await eventos_pessoas_repository.GetAllAsync();
    }

    public async Task<EVENTOS_PESSOAS?> GetByIdAsync(int id)
    {
        return await eventos_pessoas_repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(EVENTOS_PESSOAS eventoPessoa)
    {
        await eventos_pessoas_repository.AddAsync(eventoPessoa);
    }

    public async Task UpdateAsync(EVENTOS_PESSOAS eventoPessoa)
    {
        await eventos_pessoas_repository.UpdateAsync(eventoPessoa.ID, eventoPessoa);
    }

    public async Task DeleteAsync(int id)
    {
        await eventos_pessoas_repository.DeleteAsync(id);
    }

    public async Task DeleteAsync(int idEvento, int idPessoa)
    {
        await eventos_pessoas_repository.DeleteAsync(idEvento, idPessoa);
    }

    public async Task<IEnumerable<PESSOAS>> GetPessoaByEventoAsync(int eventoId)
    {
        return await eventos_pessoas_repository.GetPessoaByEventoAsync(eventoId);
    }

    public async Task<IEnumerable<PESSOAS>> GetPessoaForaEventosAsync(int eventoId)
    {
        return await eventos_pessoas_repository.GetPessoaForaEventosAsync(eventoId);
    }

    public async Task AdicionarParticipantesAsync(IEnumerable<int> idsPessoas, int eventoId)
    {
        foreach (var id in idsPessoas)
        {
            await eventos_pessoas_repository.AddAsync(new EVENTOS_PESSOAS()
            {
                CREATED_AT = DateTime.Now,
                ID_EVENTO = eventoId,
                ID_PESSOA = id,
            });
        }
    }
}
