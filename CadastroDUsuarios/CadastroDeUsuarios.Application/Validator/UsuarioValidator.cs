using CadastroDeUsuarios.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(custumer => custumer.Email).NotNull().WithMessage("Email não pode ser vazio!").NotEmpty().EmailAddress();
            RuleFor(custumer => custumer.Senha).NotNull().WithMessage("Senha não pode ser vazio!").NotEmpty();

            RuleFor(p => p).Must(BeValid);
        }

        private bool BeValid(Usuario user)
        {
            if (user.Senha.Length > 10 && user.Senha.Length < 5)
            {
                return false;
            }

            return true;
        }
    }
}
