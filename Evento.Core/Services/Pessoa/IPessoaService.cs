﻿using Evento.Core.Entities;

namespace Evento.Core.Services.Pessoa;
public interface IPessoaService
{
    Task CreateAsync(PESSOAS pessoa);
    Task DeleteAsync(int id);
    Task<IEnumerable<PESSOAS>> GetAllAsync();
    Task<PESSOAS?> GetByIdAsync(int id);
    Task UpdateAsync(PESSOAS pessoa);
}