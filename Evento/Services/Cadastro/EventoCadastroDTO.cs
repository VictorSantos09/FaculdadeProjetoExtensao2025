using Evento.Entities;

namespace Evento.Services.Cadastro;

public record EventoCadastroDTO(string Nome, string? Descricao, string? Observacao, DateTime DataInicio, DateTime DataFim);