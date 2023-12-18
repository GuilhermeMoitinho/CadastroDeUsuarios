using CadastroDeUsuarios.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuarios.WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PuxarDados()
        {
            List<Employee> ListaEmployee = new List<Employee>();
            return Ok(new { Lista = ListaEmployee });
        }
    }
}
