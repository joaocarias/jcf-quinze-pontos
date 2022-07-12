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
        private readonly ITratamentoServico _tratamentoServico;

        public ResultadoController(ILoteriasCaixaApi loteriaCaixaApi, IResultadoLotofacilRepositorio resultadoLotofacilRepositorio, IResultadoServico resultadoServico, ITratamentoServico tratamentoServico)
        {
            _loteriaCaixaApi = loteriaCaixaApi;
            _resultadoLotofacilRepositorio = resultadoLotofacilRepositorio;
            _resultadoServico = resultadoServico;
            _tratamentoServico = tratamentoServico;
        }

        [HttpPut]
        [Route("atualizarbase")]
        public async Task<IActionResult> AtualizarBaseDados(int concurso = 1) 
        {
            var consursosSalvos = await _resultadoLotofacilRepositorio.ObteTodosAsync();

            try
            {                
                var ultimoResultado = new ResultadoLotofacilDTO.Response();
                while(concurso > 0)
                {
                    //var salvos = await _resultadoLotofacilRepositorio.ObtePorConcusroAsync(concurso);
                    var salvo = consursosSalvos.Any(x => x.Concurso.Numero == concurso);
                    if(!salvo)
                    {
                        var resultado = await ObterResultadoApiAsync(concurso);
                        if (resultado != null)
                        {
                            //int[] dataProxConcursoProblema = { 2384, 2386, 2389, 2392, 2398 };

                            //if(dataProxConcursoProblema.Contains(concurso))
                            //{
                            //    resultado.dataProxConcurso = _tratamentoServico.TratarDataString(concurso, resultado.dataProxConcurso);
                            //}
                            
                            var novo = _resultadoServico.ConverterResultadoLotofacail(resultado);
                            string t = await _resultadoLotofacilRepositorio.AdicionarAsync(novo);
                            ultimoResultado = resultado;
                            if (!string.IsNullOrEmpty(t))
                            {
                                return BadRequest(ultimoResultado.concurso + " - " + t);
                            }
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
