using CadastroDeUsuarios.Domain.Entity;
using FluentValidation;
using CadastroDeUsuarios.Application.Interfaces;

namespace CadastroDeUsuarios.Application.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioService _usuarioService;

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

            var UsuarioEmail = _usuarioService.ObterEmail(user.Email);

            if(UsuarioEmail != null)
            {
                return false;
            }

            return true;
        }
    }
}
