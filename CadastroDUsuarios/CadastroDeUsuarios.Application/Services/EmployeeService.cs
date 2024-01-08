using CadastroDeUsuarios.Application.Interfaces;
using CadastroDeUsuarios.Domain.Entity;
using CadastroDeUsuarios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task EnviarDados(Employee employee)
        {
               await _context.employees.AddAsync(employee);
               await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> PuxarDados()
        {
            var listaDeFunc = await _context.employees.ToListAsync();

            return listaDeFunc;
        }
    }
}
