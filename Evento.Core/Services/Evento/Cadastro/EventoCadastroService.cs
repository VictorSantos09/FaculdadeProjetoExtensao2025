using Evento.Core.Entities;
using Evento.Core.Repositories.Interfaces;
using Evento.Core.Shared.Types;
using Evento.Core.Validators;

namespace Evento.Core.Services.Evento.Cadastro;

public class EventoCadastroService : IEventoCadastroService
{
    private readonly IEVENTOS_REPOSITORY _eventos_repository;
    private readonly EventoCadastrarValidator _validator;

    public EventoCadastroService(IEVENTOS_REPOSITORY eventos_repository, EventoCadastrarValidator validator)
    {
        _eventos_repository = eventos_repository;
        _validator = validator;
    }

    public async Task<IFinal> CadastrarAsync(EventoCadastroDTO dto)
    {
        try
        {
            var result = EVENTOS.Criar(dto.Nome, dto.Descricao, dto.Observacao, dto.DataInicio, dto.DataFim, _validator, out var caminhoQRCode);

            if (!result.IsSuccess) return result;
            if (result.Data is null) return Result.Failure("Não foi possível criar o evento.");
            await _eventos_repository.AddAsync(result.Data);

            return Result.Success();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
