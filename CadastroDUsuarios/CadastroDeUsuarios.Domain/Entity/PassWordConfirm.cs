using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Domain.Entity
{
    public class PassWordConfirm
    {
        public string EmailEsqueciSenha { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    } 
}
