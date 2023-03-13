using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Commands
{
    public class CreateDiffCommandCommandValidator : AbstractValidator<CreateDiffCommand>
    {
        public CreateDiffCommandCommandValidator()
        {
            RuleFor(p => p.Text)
               .NotEmpty().WithMessage("{Text} is required.")
               .NotNull();

            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{Id} is required.");

            RuleFor(p => p.Way)
                .NotEmpty().WithMessage("{Way} is required.")
        }
    }
}
