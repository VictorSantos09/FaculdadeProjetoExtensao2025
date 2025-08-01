﻿using BancoTalentos.Domain.Services.Imagem.Dto;
using Evento.Core.Entities;
using Evento.Core.Repositories.Interfaces;
using Evento.Core.Services.Evento.DTO;
using Evento.Core.Services.Imagem;
using Evento.Core.Services.QrCode;
using Evento.Core.Shared.Types;
using Evento.Core.Validators;

namespace Evento.Core.Services.Evento;
internal class EventoService(IEVENTOS_REPOSITORY eventos_repository,
                     EventoCadastrarValidator validator,
                     IEVENTOS_PESSOAS_REPOSITORY eventos_pessoas_repository,
                     IPESSOAS_REPOSITORY pessoas_repository,
                     IImagemService imagemService) : IEventoService
{
    const string FILE_NAME = "qrcode.png";
    public async Task<IFinal> CadastrarAsync(EVENTOS evento)
    {
        await validator.ValidateAsync(evento);

        var imagem = QrCodeService.GenerateBase64($"https://localhost:7165/confirmacaoEvento?id={evento.ID}", 10);
        ImagemBase64DTO dto = new()
        {
            FileName = FILE_NAME,
            Image = imagem,
        };
        await imagemService.ArmazenarImagemOnDiskAsync(dto);

        evento.CAMINHO_QR_CODE = dto.FileName;
        evento.CREATED_AT = DateTime.Now;
        evento.Image = await imagemService.GetImagemOnDisk(evento.CAMINHO_QR_CODE);

        await eventos_repository.AddAsync(evento);

        return Result.Success();
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

    public async Task DeleteAsync(int id)
    {
        await eventos_pessoas_repository.DeleteByIdEventoAsync(id);
        await eventos_repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(EVENTOS evento)
    {
        await eventos_repository.UpdateAsync(evento.ID, evento);
    }

    public async Task<IEnumerable<EVENTOS>> GetAllAsync()
    {
        var eventos = await eventos_repository.GetAllAsync();

        foreach (var e in eventos)
        {
            e.Image = await imagemService.GetImagemOnDisk(e.CAMINHO_QR_CODE);
        }

        return eventos;
    }

    public async Task<EVENTOS?> GetByIdAsync(int id)
    {
        return await eventos_repository.GetByIdAsync(id);
    }
}
