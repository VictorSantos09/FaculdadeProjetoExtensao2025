/*
    File Auto Generated. DO NOT MODIFY.
*/

using System.ComponentModel.DataAnnotations;

namespace Evento.Core.Entities.Base;

public class PESSOAS_BASE
{
    public int ID { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string NOME { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public DateTime DATA_NASCIMENTO { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. Use o formato 000.000.000-00.")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string EMAIL { get; set; } = string.Empty;
    public DateTime CREATED_AT { get; set; }
    public DateTime? UPDATED_AT { get; set; }
    
}
