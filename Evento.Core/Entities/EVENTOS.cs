using Evento.Entities.Base;
using Evento.Shared.Extensions;
using Evento.Shared.Types;
using Evento.Validators;

namespace Evento.Entities;

public class EVENTOS : EVENTOS_BASE
{
    public const string BASE_PATH_QR_CODE = "ConfirmacaoEvento";
    private EVENTOS()
    {
        
    }

    public static IFinal<EVENTOS?> Criar(
        string nome,
        string? descricao,
        string? observacao,
        DateTime dataInicio,
        DateTime dataFim,
        EventoCadastrarValidator validator,
        out string caminhoQRCode)
    {
        caminhoQRCode = Path.Combine(BASE_PATH_QR_CODE, $"{Guid.NewGuid()}");
        var evento = new EVENTOS()
        {
            CAMINHO_QR_CODE = caminhoQRCode,
            CREATED_AT = DateTime.Now,
            DATA_FIM = dataFim,
            DATA_INICIO = dataInicio,
            DESCRICAO = descricao,
            NOME = nome,
            OBSERVACAO = observacao,

        };
        
        var result = validator.Validate(evento);
        if (!result.IsValid) return result.ToFailure<EVENTOS>(null);

        return Result.Success(evento)!;
    }
}
