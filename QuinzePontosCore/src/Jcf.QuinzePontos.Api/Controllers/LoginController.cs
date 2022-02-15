using Jcf.QuinzePontos.Identidade.Models;
using Jcf.QuinzePontos.Identidade.Repositorio;
using Jcf.QuinzePontos.Identidade.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.QuinzePontos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserApp model)
        {
            var user = UserRepositorio.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou Senha Inválida!" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token,
            };
        }
    }
}
