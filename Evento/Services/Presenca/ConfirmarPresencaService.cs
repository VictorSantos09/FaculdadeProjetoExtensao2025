using Evento.Repositories.Interfaces;
using Evento.Shared.Types;

namespace Evento.Services.Presenca;

public class ConfirmarPresencaService : IConfirmarPresencaService
{
    private readonly IEVENTOS_REPOSITORY _eventos_repository;
    private readonly IEVENTOS_PESSOAS_REPOSITORY _eventos_pessoas_repository;
    private readonly IPESSOAS_REPOSITORY _pessoas_repository;

    public ConfirmarPresencaService(IEVENTOS_REPOSITORY eventos_repository,
                                    IEVENTOS_PESSOAS_REPOSITORY eventos_pessoas_repository,
                                    IPESSOAS_REPOSITORY pessoas_repository)
    {
        _eventos_repository = eventos_repository;
        _eventos_pessoas_repository = eventos_pessoas_repository;
        _pessoas_repository = pessoas_repository;
    }

    public async Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto)
    {
        var pessoa = await _pessoas_repository.GetByCPF(dto.Cpf);
        var evento = await _eventos_repository.GetByIdAsync(dto.Id);

        if (pessoa is null) return Result.Failure("Não foi encontrada uma pessoa com o CPF fornecido.");
        if (evento is null) return Result.Failure($"Não foi encontrado o evento com código '{dto.Id}'.");
        
        var eventoPessoa = await _eventos_pessoas_repository.GetByEventoPessoaAsync(pessoa.ID, evento.ID);
        if (eventoPessoa is null) return Result.Failure($"A pessoa '{pessoa.NOME}' não está inscrita para o evento '{evento.NOME}'.");

        if (eventoPessoa.DATA_CONFIRMACAO is not null) return Result.Failure("Presença já confirmada anteriormente.");

        eventoPessoa.UPDATED_AT = DateTime.Now;
        eventoPessoa.DATA_CONFIRMACAO = DateTime.Now;

        await _eventos_pessoas_repository.UpdateAsync(eventoPessoa.ID, eventoPessoa);

        return Result.Success("Presença confirmada.");
    }
}
