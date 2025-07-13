using FluentValidation.Results;
using System.Collections.Immutable;

namespace Evento.Core.Shared.Types;

public class Result(object? data, bool isSuccess, IEnumerable<ValidationFailureCustom>? failures) : Final<object>(data, isSuccess, failures)
{
    public static IFinal Success() => new Final<object>(null, true, null);
    public static IFinal<T?> Success<T>(T? data) => new Final<T?>(data, true, null);
    #region FAILURE SEM T
    public static IFinal Failure(IEnumerable<ValidationFailureCustom> failures) => new Final<object>(null, false, failures);
    public static IFinal Failure(ValidationFailureCustom failure) => new Final<object>(null, false, [failure]);
    public static IFinal Failure(string reason)
    {
        if (string.IsNullOrEmpty(reason))
        {
            throw new ArgumentException($"'{nameof(reason)}' cannot be null or empty.", nameof(reason));
        }

        return new Final<object>(null, false, null, reason);
    }
    #endregion
    #region FAILURE COM T
    public static IFinal<T?> Failure<T>(T? data, IEnumerable<ValidationFailureCustom> failures) => new Final<T?>(data, false, failures);
    public static IFinal<T?> Failure<T>(T? data, ValidationFailureCustom failure)
        => new Final<T>(data, false, [failure]);
    #endregion
}

public class Final<T>(T? data, bool isSuccess, IEnumerable<ValidationFailureCustom>? failures, string? reason = null) : IFinal<T>
{
    public T? Data { get; init; } = data;
    public bool IsSuccess { get; } = isSuccess;
    public IEnumerable<ValidationFailureCustom>? Failures { get; } = failures?.ToImmutableArray();
    public string? Reason { get; } = reason;
}

public interface IFinal<T> : IFinal
{
    T? Data { get; init; }
}

public interface IFinal
{
    bool IsSuccess { get; }
    string Reason { get; }
    IEnumerable<ValidationFailureCustom>? Failures { get; }
}