using Evento.Entities.Base;

/*
    File Auto Generated. DO NOT MODIFY.
*/

namespace Evento.Repositories.Base.Interfaces;

public interface IEVENTOS_REPOSITORY_BASE<T> where T : EVENTOS_BASE
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T parameters);
    Task UpdateAsync(int id, T parameters);
    Task<int> DeleteAsync(int id);
}
