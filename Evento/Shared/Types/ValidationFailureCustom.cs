using FluentValidation;
using FluentValidation.Results;

namespace Evento.Shared.Types;

public class ValidationFailureCustom
{
    /// <summary>
	/// The name of the property.
	/// </summary>
	public string PropertyName { get; set; }

    /// <summary>
    /// The error message
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// The property value that caused the failure.
    /// </summary>
    public object AttemptedValue { get; set; }

    /// <summary>
    /// Custom severity level associated with the failure.
    /// </summary>
    public Severity Severity { get; set; } = Severity.Error;

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string ErrorCode { get; set; }

    public ValidationFailureCustom()
    {
        
    }

    public ValidationFailureCustom(string propertyName, string errorMessage, object attemptedValue, Severity severity, string errorCode)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
        AttemptedValue = attemptedValue;
        Severity = severity;
        ErrorCode = errorCode;
    }

    public static ValidationFailureCustom FromFluentValidation(ValidationFailure validationFailure)
    {
        return new(validationFailure.PropertyName,
                   validationFailure.ErrorMessage,
                   validationFailure.AttemptedValue,
                   validationFailure.Severity,
                   validationFailure.ErrorCode);
    }
}
