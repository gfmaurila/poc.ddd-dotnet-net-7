﻿using Auth.Domain.Entities.Users;
using FluentValidation;

namespace Auth.Domain.Validators;
public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("O nome não pode ser nulo.")

            .NotEmpty()
            .WithMessage("O nome não pode ser vazio.")

            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 caracteres.")

            .MaximumLength(80)
            .WithMessage("O nome deve ter no máximo 80 caracteres.");

    }
}
