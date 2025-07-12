using BancoTalentos.Domain.Services.Imagem.Dto;
using Evento.Core.Entities.Base;

namespace Evento.Core.Entities;

public class EVENTOS : EVENTOS_BASE
{
    public ImagemDTO Image { get; set; }
}
