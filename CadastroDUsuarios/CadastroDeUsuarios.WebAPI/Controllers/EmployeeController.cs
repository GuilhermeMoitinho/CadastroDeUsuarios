using CadastroDeUsuarios.Application.Interfaces;
using CadastroDeUsuarios.Domain.Entity;
using CadastroDeUsuarios.Infrastructure.Context;
using CadastroDeUsuarios.WebAPI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuarios.WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService )
        {
            _EmployeeService = EmployeeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PuxarDados()
        {

            var listaDeCadatro = _EmployeeService.PuxarDados(); 

            return Ok(new { Lista = listaDeCadatro });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EnviarDados(Employee employee)
        {
            if (employee == null) return BadRequest();

            await _EmployeeService.EnviarDados(employee);

            return Ok(new { id =  employee.Id });
        }

    }
}
