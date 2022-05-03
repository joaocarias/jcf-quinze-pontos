using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Refit;

namespace Jcf.Client.LoteriaCaixa.Api.LoteriaCaixaApi
{
    public interface ILoteriasCaixaApi
    {
        [Get("/lotofacil/{concurso}")]
        Task<ResultadoLotofacilDTO.Response> GetResultadoLotofacil(string concurso);
    }
}
