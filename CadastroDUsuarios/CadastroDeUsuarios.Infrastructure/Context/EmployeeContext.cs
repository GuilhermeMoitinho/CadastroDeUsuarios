using CadastroDeUsuarios.Domain.Entity;
using CadastroDeUsuarios.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Infrastructure.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }


        public DbSet<Employee> employees { get; set; }
    }
}
