namespace Evento.Core.Services.Evento.DTO;

public record EventoCadastroDTO(string Nome, string? Descricao, string? Observacao, DateTime DataInicio, DateTime DataFim);