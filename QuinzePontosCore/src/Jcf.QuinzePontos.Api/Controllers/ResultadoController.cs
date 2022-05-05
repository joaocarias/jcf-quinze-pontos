using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Jcf.Client.LoteriaCaixa.Api.LoteriaCaixaApi;
using Jcf.QuinzePontos.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.QuinzePontos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly ILoteriasCaixaApi _loteriaCaixaApi;
        private readonly IResultadoLotofacilRepositorio _resultadoLotofacilRepositorio;

        public ResultadoController(ILoteriasCaixaApi loteriaCaixaApi, IResultadoLotofacilRepositorio resultadoLotofacilRepositorio)
        {
            _loteriaCaixaApi = loteriaCaixaApi;
            _resultadoLotofacilRepositorio = resultadoLotofacilRepositorio;
        }

        [HttpPut]
        [Route("atualizarbase")]
        public async Task<IActionResult> AtualizarBaseDados() 
        {
            var concurso = 1;
            try
            {
                var ultimoResultado = new ResultadoLotofacilDTO.Response();
                while(concurso > 0)
                {
                    var concursoSalvo = await _resultadoLotofacilRepositorio.ObtePorConcusroAsync(concurso);

                    var resultado = await _loteriaCaixaApi.GetResultadoLotofacil(Convert.ToString(concurso));
                    if(resultado != null)
                    {
                        ultimoResultado = resultado;
                        concurso++;
                    }
                    else
                    {
                        concurso = -1;
                    }
                }

                return Ok(ultimoResultado);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest("valor de i: " + concurso + " - " + message);
            }
        }
    }
}
