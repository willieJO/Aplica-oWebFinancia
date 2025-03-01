using APIFinancia.Application.Commands;
using FluentValidation;

namespace APIFinancia.Application.Validators
{
    public class GastoCommandValidator : AbstractValidator<CreateGastoCommand>
    {
        public GastoCommandValidator()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor do gasto deve ser maior que zero.")
                .NotEmpty().WithMessage("O valor é obrigatório.")
                .PrecisionScale(18, 2, true)
                .WithMessage("O valor deve ter até 18 dígitos no total, sendo 2 após a vírgula.");

            RuleFor(x => x.TipoGasto)
                .NotEmpty().WithMessage("O tipo de gasto é obrigatório.")
                .MaximumLength(100).WithMessage("O tipo de gasto pode ter no máximo 100 caracteres.");

            RuleFor(x => x.UsuarioId)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");
        }
    }
}
