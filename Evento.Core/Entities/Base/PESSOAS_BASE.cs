/*
    File Auto Generated. DO NOT MODIFY.
*/

using System.ComponentModel.DataAnnotations;

namespace Evento.Core.Entities.Base;

public class PESSOAS_BASE
{
    public int ID { get; set; }

    [Required(ErrorMessage = "O nome � obrigat�rio.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no m�ximo 100 caracteres.")]
    public string NOME { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento � obrigat�ria.")]
    public DateTime DATA_NASCIMENTO { get; set; }

    [Required(ErrorMessage = "O CPF � obrigat�rio.")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail � obrigat�rio.")]
    [EmailAddress(ErrorMessage = "E-mail inv�lido.")]
    public string EMAIL { get; set; } = string.Empty;
    public DateTime CREATED_AT { get; set; }
    public DateTime? UPDATED_AT { get; set; }
    
}
