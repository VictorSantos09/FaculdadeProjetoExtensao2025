using Evento.Entities;
using Evento.Repositories.Interfaces;

namespace Evento.Services.Pessoa;

public class PessoaService(IPESSOAS_REPOSITORY pessoas_repository) : IPessoaService
{
    public async Task<IEnumerable<PESSOAS>> GetAllAsync()
    {
        return await pessoas_repository.GetAllAsync();
    }

    public async Task<PESSOAS?> GetByIdAsync(int id)
    {
        return await pessoas_repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(PESSOAS pessoa)
    {
        await pessoas_repository.AddAsync(pessoa);
    }

    public async Task UpdateAsync(PESSOAS pessoa)
    {
        await pessoas_repository.UpdateAsync(pessoa.ID, pessoa);
    }

    public async Task DeleteAsync(int id)
    {
        await pessoas_repository.DeleteAsync(id);
    }
}
