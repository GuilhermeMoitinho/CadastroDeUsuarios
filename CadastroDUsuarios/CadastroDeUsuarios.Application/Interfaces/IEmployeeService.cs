using CadastroDeUsuarios.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> PuxarDados();

        public Task EnviarDados(Employee employee);
    }
}
