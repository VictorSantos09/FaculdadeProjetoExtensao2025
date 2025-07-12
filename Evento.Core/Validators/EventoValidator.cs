using Evento.Core.Entities;
using Evento.Core.Shared.Types;
using FluentValidation;

namespace Evento.Core.Validators
{
    public class EventoCadastrarValidator : AbstractValidator<EVENTOS>
    {
        public EventoCadastrarValidator()
        {
            RuleFor(x => x.NOME)
                .NotEmpty().WithMessage(ValidationMessage.Default.CAMPO_OBRIGATORIO)
                .Length(3, 75).WithMessage("O nome do evento deve ter entre 3 e 75 caracteres.");

            RuleFor(x => x.DATA_INICIO)
                .NotEmpty().WithMessage(ValidationMessage.Default.CAMPO_OBRIGATORIO)
                .Must(data => data.Date >= DateTime.UtcNow.Date)
                .WithMessage("Data de início deve ser hoje ou uma data futura.");

            RuleFor(x => x.DATA_FIM)
                .NotEmpty().WithMessage(ValidationMessage.Default.CAMPO_OBRIGATORIO)
                .GreaterThan(x => x.DATA_INICIO).WithMessage("A data de fim deve ser posterior à data de início.");

            RuleFor(x => x.CREATED_AT)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de criação não pode ser no futuro.");
        }
    }

    public class EventoAtualizarValidator : EventoCadastrarValidator
    {
        public EventoAtualizarValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage(ValidationMessage.Default.CAMPO_OBRIGATORIO);

            RuleFor(x => x.CAMINHO_QR_CODE)
                .NotEmpty().WithMessage(ValidationMessage.Default.CAMPO_OBRIGATORIO);

            RuleFor(x => x.UPDATED_AT)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de atualização não pode ser no futuro.");
        }
    }
}
