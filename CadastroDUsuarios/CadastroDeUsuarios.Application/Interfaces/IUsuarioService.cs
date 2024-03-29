﻿using CadastroDeUsuarios.Application.AutoMapper.Mappings;
using CadastroDeUsuarios.Application.ServiceResponse;
using CadastroDeUsuarios.Domain.Entity;

namespace CadastroDeUsuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioLoginResponseContract> Cadastro(Usuario UserCadastro);
        Task<UsuarioLoginResponseContract> Login(UsuarioLoginRequestContract userLogin);
        Task<Usuario> BuscarUsuariosPorId(Guid id);
        Task<IEnumerable<Usuario>> BuscarTodosUsuarios();
        Task EsqueciSenha(PassWordConfirm passWordConfirm);

        Task<Usuario?> Obter(string email, string senha);

        Task<Usuario?> ObterEmail(string email);
    }
}
