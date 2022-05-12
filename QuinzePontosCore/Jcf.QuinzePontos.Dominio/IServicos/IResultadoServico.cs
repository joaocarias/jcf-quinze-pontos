using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Jcf.QuinzePontos.Dominio.Entidades;

namespace Jcf.QuinzePontos.Dominio.IServicos
{
    public interface IResultadoServico
    {
        ResultadoLotofacil ConverterResultadoLotofacail(ResultadoLotofacilDTO.Response resultado);

        Concurso ConverterConcunsoLotocafil(ResultadoLotofacilDTO.Response resultado);

        IList<Premiacao> ConverterPremiacaoLotofacil(ResultadoLotofacilDTO.Response resultado);

        IList<EstadoPremiado> ConverterEstadoPremiadoLotofacil(ResultadoLotofacilDTO.Response resultado);
    }
}
