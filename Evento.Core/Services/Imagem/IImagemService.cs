using BancoTalentos.Domain.Services.Imagem.Dto;

namespace Evento.Core.Services.Imagem;
internal interface IImagemService
{
    Task<string> ArmazenarFotoOnDiskAsync(ImagemBase64DTO dto, CancellationToken cancellationToken = default);
    Task<string> ArmazenarFotoPerfilOnDiskAsync(ImagemBase64DTO dto, CancellationToken cancellationToken = default);
    void DeletarImagemOnDisk(string fileName);
    Task<ImagemDTO> GetImagemOnDisk(string fileName, CancellationToken cancellationToken = default);
}