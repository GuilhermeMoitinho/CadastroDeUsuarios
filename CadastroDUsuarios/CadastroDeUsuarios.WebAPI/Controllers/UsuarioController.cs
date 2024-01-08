using CadastroDeUsuarios.Application.Auth;
using CadastroDeUsuarios.Application.Interfaces;
using CadastroDeUsuarios.Application.ServiceResponse;
using CadastroDeUsuarios.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/users")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")] // Adicione um sufixo "cadastro"
    public async Task<IActionResult> Cadastro(Usuario userCadastro)
    {
        return Ok(await _usuarioService.Cadastro(userCadastro));
    }

    [HttpPost("login")] // Adicione um sufixo "login"
    public async Task<IActionResult> Login(Usuario userLogin)
    {
        var user = await _usuarioService.Obter(userLogin.Email, userLogin.Senha);

        if (user == null)
        {
            var respostaNEncontrada = new UsuarioLoginResponseContract() { Email = "Usuario nao encontrado", Token = "Usuario nao encontrado" };

            return NotFound(respostaNEncontrada);
        }

        return Ok(await _usuarioService.Login(userLogin));
    }

    [Authorize]
    [HttpPut("esqueciSenha")]
    public async Task<IActionResult> EsqueciSenha(PassWordConfirm mudarSenha)
    {
        if (mudarSenha == null) return BadRequest();

         await _usuarioService.EsqueciSenha(mudarSenha);

        return Ok();
    }
}
