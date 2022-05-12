using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Jcf.Client.LoteriaCaixa.Api.LoteriaCaixaApi;
using Jcf.QuinzePontos.Dominio.IRepositorios;
using Jcf.QuinzePontos.Dominio.IServicos;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.QuinzePontos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly ILoteriasCaixaApi _loteriaCaixaApi;
        private readonly IResultadoLotofacilRepositorio _resultadoLotofacilRepositorio;
        private readonly IResultadoServico _resultadoServico;

        public ResultadoController(ILoteriasCaixaApi loteriaCaixaApi, IResultadoLotofacilRepositorio resultadoLotofacilRepositorio, IResultadoServico resultadoServico)
        {
            _loteriaCaixaApi = loteriaCaixaApi;
            _resultadoLotofacilRepositorio = resultadoLotofacilRepositorio;
            _resultadoServico = resultadoServico;
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
                    var salvos = await _resultadoLotofacilRepositorio.ObtePorConcusroAsync(concurso);

                    if(!salvos.Any())
                    {
                        var resultado = await ObterResultadoApiAsync(concurso);
                        if (resultado != null)
                        {
                            var novo = _resultadoServico.ConverterResultadoLotofacail(resultado);
                            var t = _resultadoLotofacilRepositorio.AdicionarAsync(novo);
                            ultimoResultado = resultado; 
                        }
                        else
                        {
                            concurso = -1;
                        }
                    }

                    concurso++;
                }

                return Ok(ultimoResultado);
            }
            catch (Exception ex)
            {                
                return BadRequest("valor de i: " + concurso + " - " + ex.Message);
            }
        }

        private async Task<ResultadoLotofacilDTO.Response> ObterResultadoApiAsync(int concurso)
        {
            try
            {
               var r = await _loteriaCaixaApi.GetResultadoLotofacil(Convert.ToString(concurso));
                return r;
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
