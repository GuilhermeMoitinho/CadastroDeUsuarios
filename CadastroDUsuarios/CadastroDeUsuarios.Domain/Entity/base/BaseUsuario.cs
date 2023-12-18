using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Domain.Entity
{
    public abstract class BaseUsuario
    {
        public Guid Id { get; private set; }

        public BaseUsuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
