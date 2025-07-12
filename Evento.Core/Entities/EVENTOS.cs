using BancoTalentos.Domain.Services.Imagem.Dto;
using Evento.Core.Entities.Base;

namespace Evento.Core.Entities;

public class EVENTOS : EVENTOS_BASE
{
    public const string BASE_PATH_QR_CODE = "ConfirmacaoEvento";
    public ImagemDTO Image { get; set; }
}
