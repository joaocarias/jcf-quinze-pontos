using Jcf.Client.LoteriaCaixa.Api.LoteriaCaixaApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.QuinzePontos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoteriasCaixaApi _loteriaCaixaApi;

        public HomeController(ILoteriasCaixaApi loteriaCaixaApi)
        {
            _loteriaCaixaApi = loteriaCaixaApi;
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

        [HttpGet]
        [Route("teste")]
        public async Task<IActionResult> Teste()
        {
            try
            {
                var resultado = await _loteriaCaixaApi.GetResultadoLotofacil("2508");
                if (resultado == null)
                    BadRequest();
                return Ok(resultado);
            }catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
            
        }
    }
}
