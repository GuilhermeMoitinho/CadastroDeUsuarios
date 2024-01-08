using CadastroDeUsuarios.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Validator
{
    public class ConfirmaSenhaValidator : AbstractValidator<PassWordConfirm>
    {
        public ConfirmaSenhaValidator()
        {

            RuleFor(custumer => custumer.EmailEsqueciSenha).NotNull().WithMessage("Email não pode ser vazio!").NotEmpty();

            RuleFor(custumer => custumer.PassWord).NotNull().WithMessage("PassWord não pode ser vazio!").NotEmpty();

            RuleFor(custumer => custumer.ConfirmPassWord).NotNull().WithMessage("Comfirmação de PassWord não pode ser vazio!").NotEmpty();

            RuleFor(p => p).Must(BeValid).WithMessage("Veja se: As senhas se conferem ou se os dados do Email não estão inválidos!");
        }

        private bool BeValid(PassWordConfirm passwordConfirm)
        {
            if (passwordConfirm.EmailEsqueciSenha.Equals("string") || passwordConfirm.PassWord.Equals("string") || passwordConfirm.ConfirmPassWord.Equals("string"))
            {
                return false;
            }

            if (passwordConfirm.PassWord != passwordConfirm.ConfirmPassWord)
            {
                return false;
            }

            return true;
        }
    }
}
