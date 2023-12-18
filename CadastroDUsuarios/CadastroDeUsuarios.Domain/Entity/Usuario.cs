using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Domain.Entity
{
    public class Usuario : BaseUsuario
    {
        [Required(ErrorMessage = "O campo de E-mail é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        public string Senha { get; set; } = string.Empty;

        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataInativacao { get; set; } = DateTime.Now;
    }
}
