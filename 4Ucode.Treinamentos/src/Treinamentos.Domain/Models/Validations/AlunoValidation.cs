using FluentValidation;
using Treinamentos.Domain.Model;

namespace DevIO.Business.Models.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}