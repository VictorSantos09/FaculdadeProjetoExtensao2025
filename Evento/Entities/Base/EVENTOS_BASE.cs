namespace Evento.Entities.Base;

public class EVENTOS_BASE
{
    public int ID { get; set; }
    public string NOME { get; set; }
    public string? DESCRICAO { get; set; }
    public string? OBSERVACAO { get; set; }
    public DateTime DATA_INICIO { get; set; }
    public DateTime DATA_FIM { get; set; }
    public string CAMINHO_QR_CODE { get; set; }
    public DateTime CREATED_AT { get; set; }
    public DateTime? UPDATED_AT { get; set; }
    
}
