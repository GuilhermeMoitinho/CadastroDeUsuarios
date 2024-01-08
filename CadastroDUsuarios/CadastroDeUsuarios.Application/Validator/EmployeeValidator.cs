using CadastroDeUsuarios.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(custumer => custumer.name).NotNull().WithMessage("Nome não pode ser vazio!").NotEmpty();

            RuleFor(custumer => custumer.age).NotNull().WithMessage("Idade não pode ser vazia!").NotEmpty();

            RuleFor(p => p).Must(BeValid).WithMessage("Veja se: Seu nome não está inválido ou se sua idade não está inválida!");
        }

        private bool BeValid(Employee employee)
        {
            if (employee.name.Equals("string"))
            {
                return false;
            }

            if(employee.age > 100)
            {
                return false;
            }

            return true;
        }
    }
}
