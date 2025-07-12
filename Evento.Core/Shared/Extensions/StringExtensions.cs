namespace Evento.Shared.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
    public static bool IsEmptyOrWhieSpace(this string value) => string.IsNullOrWhiteSpace(value);
}
