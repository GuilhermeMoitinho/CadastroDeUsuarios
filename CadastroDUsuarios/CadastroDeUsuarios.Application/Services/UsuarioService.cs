﻿using CadastroDeUsuarios.Application.Auth;
using CadastroDeUsuarios.Application.AutoMapper.Mappings;
using CadastroDeUsuarios.Application.Interfaces;
using CadastroDeUsuarios.Application.ServiceResponse;
using CadastroDeUsuarios.Domain.Entity;
using CadastroDeUsuarios.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuarios.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CadastroContext _contexto;
        private readonly TokenService _tokenService;

        public UsuarioService(CadastroContext context, TokenService tokenService)
        {
            _contexto = context;
            _tokenService = tokenService;
        }

        public async Task<UsuarioLoginResponseContract> Cadastro(Usuario UserCadastro)
        {
            await _contexto.usuarios.AddAsync(UserCadastro);
            await _contexto.SaveChangesAsync();

            var result = new UsuarioLoginResponseContract()
            {
                Id = UserCadastro.Id,
                Email = UserCadastro.Email,
                Token = "Execute o Login para receber o Token."
            };

            return result;
        }

        public async Task<Usuario?> Obter(string email, string senha)
        {
            var user = await _contexto.usuarios.AsNoTracking()
                                           .Where(u => u.Email == email && u.Senha == senha)
                                           .FirstOrDefaultAsync();

            return user;
        }

        public async Task<UsuarioLoginResponseContract> Login(Usuario userLogin)
        {

            var result = new UsuarioLoginResponseContract()
            {
                Id = userLogin.Id,
                Email = userLogin.Email,
                Token = _tokenService.GenerateToken(userLogin)
            };

            return result;
        }

        public async Task EsqueciSenha(PassWordConfirm passWordConfirm)
        {
            var User = await _contexto.usuarios.FirstOrDefaultAsync(user => passWordConfirm.EmailEsqueciSenha == user.Email);

            User.Senha = passWordConfirm.ConfirmPassWord;


            _contexto.usuarios.Update(User);
            await _contexto.SaveChangesAsync();
        }
    }
}