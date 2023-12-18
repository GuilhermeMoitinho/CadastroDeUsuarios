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


            ListaEmployee.Add(new Employee("Rafaela", 25, "foto1.jpg", "https://orofacial.com.br/wp-content/uploads/2014/10/60-1.jpg"));
            ListaEmployee.Add(new Employee("Maria", 30, "foto2.jpg", "https://img.freepik.com/fotos-gratis/o-lindo-rosto-feminino-a-pele-perfeita-e-limpa-do-rosto-em-branco-a-beleza-cuidados-pele-tratamento-saude-spa-conceito-cosmetico_155003-40141.jpg?t=st=1702941863~exp=1702942463~hmac=623226be22f356e190c561468a669f1c24ab7ab4bf5c0d783d509e69b412209b"));
            ListaEmployee.Add(new Employee("Carlos", 28, "foto3.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Ana", 22, "foto4.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Pedro", 35, "foto5.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Laura", 27, "foto6.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Fernando", 40, "foto7.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Julia", 32, "foto8.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Gabriel", 29, "foto9.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));
            ListaEmployee.Add(new Employee("Mariana", 26, "foto10.jpg", "https://cdn.pixabay.com/photo/2017/02/16/23/10/smile-2072907_1280.jpg/"));


            return Ok(new { Lista = ListaEmployee });
        }
    }
}
