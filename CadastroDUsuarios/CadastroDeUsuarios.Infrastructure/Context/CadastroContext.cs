using CadastroDeUsuarios.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuarios.WebAPI.Context
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

        public DbSet<Usuario> usuarios { get; set; }
    }
}
