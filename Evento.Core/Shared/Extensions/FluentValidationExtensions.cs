using Evento.Shared.Types;
using FluentValidation.Results;

namespace Evento.Shared.Extensions;

public static class FluentValidationExtensions
{
    public static IFinal<T?> ToFailure<T>(this ValidationResult result, T? data)
    {
        return Result.Failure(data, result.Errors.Select(ValidationFailureCustom.FromFluentValidation));
    }
}
