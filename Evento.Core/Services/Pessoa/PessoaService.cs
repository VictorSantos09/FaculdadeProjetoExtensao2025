using Evento.Core.Entities;
using Evento.Core.Repositories.Interfaces;

namespace Evento.Core.Services.Pessoa;

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
        pessoa.CREATED_AT = DateTime.Now;
        await pessoas_repository.AddAsync(pessoa);
    }

    public async Task UpdateAsync(PESSOAS pessoa)
    {
        pessoa.UPDATED_AT = DateTime.Now;
        await pessoas_repository.UpdateAsync(pessoa.ID, pessoa);
    }

    public async Task DeleteAsync(int id)
    {
        await pessoas_repository.DeleteAsync(id);
    }
}
