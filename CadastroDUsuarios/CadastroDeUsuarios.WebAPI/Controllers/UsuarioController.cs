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
        if (userCadastro is null) return BadRequest();

        var result = await _usuarioService.Cadastro(userCadastro);

        return CreatedAtAction(nameof(BuscarUsuariosPorId), new {id = result.Id}, result);
    }

    [Authorize]
    [ActionName("BuscarUsuariosPorId")]
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuariosPorId(Guid id)
    {
        if(id == Guid.Empty || id == null) return BadRequest();

        var user = await _usuarioService.BuscarUsuariosPorId(id);
        
        return Ok(user);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> BuscarTodosUsuarios()
    {
        return Ok(await _usuarioService.BuscarTodosUsuarios());
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

        return NoContent();
    }
}
