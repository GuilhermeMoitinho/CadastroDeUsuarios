using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using CadastroDeUsuarios.Domain.Entity;
using System.Text;
using System.Threading.Tasks;
using CadastroDeUsuarios.Application.ServiceResponse;
using CadastroDeUsuarios.Application.AutoMapper.Mappings;

namespace CadastroDeUsuarios.Application.AutoMapper
{
    internal class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioLoginRequestContract>().ReverseMap();
            CreateMap<UsuarioLoginRequestContract, Usuario>().ReverseMap();
        }
    }
}
