using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeUsuarios.Application.ServiceResponse;
using CadastroDeUsuarios.Application.AutoMapper.Mappings;
using CadastroDeUsuarios.Domain.Entity;

namespace CadastroDeUsuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioLoginResponseContract> Cadastro(Usuario UserCadastro);
        Task<UsuarioLoginResponseContract> Login(Usuario userLogin);

        Task<Usuario?> Obter(string email);
    }
}
