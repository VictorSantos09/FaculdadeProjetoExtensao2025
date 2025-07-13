namespace Evento.Core.Extensions;
public static class StringExtensions
{
    public static string FormatarCpf(this string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return string.Empty;
        var numeros = new string(cpf.Where(char.IsDigit).ToArray());
        return numeros.Length == 11 ? $"{numeros[..3]}.{numeros[3..6]}.{numeros[6..9]}-{numeros[9..]}" : cpf;
    }
}
