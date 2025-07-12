using BancoTalentos.Domain.Services.Imagem.Dto;
using SenacPlataform.Shared.Exceptions;
using System.Net.Mime;

namespace Evento.Core.Services.Imagem;

internal class ImagemService : IImagemService
{
    public async Task<string> ArmazenarImagemOnDiskAsync(ImagemBase64DTO dto, CancellationToken cancellationToken = default)
    {
        dto.FileName = $"{Guid.NewGuid()}__{dto.FileName}";
        return await ArmazenarFotoOnDiskAsync(dto, cancellationToken);
    }

    public static string GetPath(string fileName)
    {
        var path = GetPath();
        path = Path.Combine(path, fileName);
        return path;
    }

    public static string GetPath()
    {
        return Path.Combine(Path.GetTempPath(), "ConfirmacaoEvento");
    }

    public async Task<string> ArmazenarFotoOnDiskAsync(ImagemBase64DTO dto, CancellationToken cancellationToken = default)
    {
        var filePath = GetPath();
        Directory.CreateDirectory(filePath);
        filePath = Path.Combine(filePath, dto.FileName);

        await SaveImageAsync(dto, filePath, 0, cancellationToken);

        return dto.FileName;
    }

    public void DeletarImagemOnDisk(string fileName)
    {
        var path = GetPath();

        path = Path.Combine(path, fileName);
        File.Delete(path);
    }

    /// <summary>
    /// Obtém uma imagem do disco a partir do nome do arquivo.
    /// </summary>
    /// <param name="fileName">Nome do arquivo da imagem.</param>
    /// <param name="cancellationToken">Token de cancelamento para operações canceláveis.</param>
    /// <returns>Objeto Image representando a imagem.</returns>
    public async Task<ImagemDTO> GetImagemOnDisk(string fileName, CancellationToken cancellationToken = default)
    {
        var path = GetPath(fileName);

        if (!File.Exists(path))
        {
            throw new ImageNotFoundException("O arquivo da imagem não foi encontrado.", path);
        }

        // Load file meta data with FileInfo
        FileInfo fileInfo = new FileInfo(path);

        // The byte[] to save the data in
        byte[] data = new byte[fileInfo.Length];

        // Load a filestream and put its content into the byte[]
        using (FileStream fs = fileInfo.OpenRead())
        {
            fs.Read(data, 0, data.Length);
        }

        // Lê o arquivo de imagem diretamente como array de bytes
        //var imageBytes = await File.ReadAllBytesAsync(path, cancellationToken);


        // Converte os bytes da imagem para Base64
        string base64String = Convert.ToBase64String(data);

        // Determina o tipo MIME com base na extensão do arquivo
        string mimeType = fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ? "image/png" :
                          fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ? "image/jpeg" :
                          MediaTypeNames.Application.Octet;

        return new ImagemDTO(mimeType, base64String);
    }


    private async Task SaveImageAsync(ImagemBase64DTO dto, string filePath, int compressionAmount, CancellationToken cancellationToken)
    {
        byte[] decodedBytes = Convert.FromBase64String(dto.Image);
        File.WriteAllBytes(filePath, decodedBytes);
    }
}