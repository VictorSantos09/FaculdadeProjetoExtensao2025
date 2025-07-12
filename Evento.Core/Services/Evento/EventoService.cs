using Evento.Core.Entities;
using Evento.Core.Repositories.Interfaces;
using Evento.Core.Services.Evento.DTO;
using Evento.Core.Shared.Types;
using Evento.Core.Validators;

namespace Evento.Core.Services.Evento;
internal class EventoService(IEVENTOS_REPOSITORY eventos_repository,
                     EventoCadastrarValidator validator,
                     IEVENTOS_PESSOAS_REPOSITORY eventos_pessoas_repository,
                     IPESSOAS_REPOSITORY pessoas_repository) : IEventoService
{
    public async Task<IFinal> CadastrarAsync(EVENTOS evento)
    {
        try
        {
            await validator.ValidateAsync(evento);
            var caminhoQRCode = Path.Combine(EVENTOS.BASE_PATH_QR_CODE, $"{Guid.NewGuid()}");

            await eventos_repository.AddAsync(evento);

            return Result.Success();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IFinal> ConfirmarAsync(ConfirmarPresencaDTO dto)
    {
        var pessoa = await pessoas_repository.GetByCPF(dto.Cpf);
        var evento = await eventos_repository.GetByIdAsync(dto.Id);

        if (pessoa is null) return Result.Failure("Não foi encontrada uma pessoa com o CPF fornecido.");
        if (evento is null) return Result.Failure($"Não foi encontrado o evento com código '{dto.Id}'.");

        var eventoPessoa = await eventos_pessoas_repository.GetByEventoPessoaAsync(pessoa.ID, evento.ID);
        if (eventoPessoa is null) return Result.Failure($"A pessoa '{pessoa.NOME}' não está inscrita para o evento '{evento.NOME}'.");

        if (eventoPessoa.DATA_CONFIRMACAO is not null) return Result.Failure("Presença já confirmada anteriormente.");

        eventoPessoa.UPDATED_AT = DateTime.Now;
        eventoPessoa.DATA_CONFIRMACAO = DateTime.Now;

        await eventos_pessoas_repository.UpdateAsync(eventoPessoa.ID, eventoPessoa);

        return Result.Success("Presença confirmada.");
    }
}
