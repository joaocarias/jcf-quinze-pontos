using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Jcf.QuinzePontos.Dominio.Constantes;
using Jcf.QuinzePontos.Dominio.Entidades;
using Jcf.QuinzePontos.Dominio.Enums;
using Jcf.QuinzePontos.Dominio.IServicos;

namespace Jcf.QuinzePontos.Infraestrutura.Servicos
{
    public class ResultadoServico : IResultadoServico
    {
        public Concurso? ConverterConcunsoLotocafil(ResultadoLotofacilDTO.Response resultado)
        {
            decimal valorAposta = new decimal(2);
            DateTime? dataRealizacao = DateTime.Now;

            var concurso = new Concurso(
                    resultado.concurso,
                    dataRealizacao,

                    int.Parse(resultado.dezenas[0]),
                    int.Parse(resultado.dezenas[1]),
                    int.Parse(resultado.dezenas[2]),
                    int.Parse(resultado.dezenas[3]),
                    int.Parse(resultado.dezenas[4]),

                    int.Parse(resultado.dezenas[5]),
                    int.Parse(resultado.dezenas[6]),
                    int.Parse(resultado.dezenas[7]),
                    int.Parse(resultado.dezenas[8]),
                    int.Parse(resultado.dezenas[9]),

                    int.Parse(resultado.dezenas[10]),
                    int.Parse(resultado.dezenas[11]),
                    int.Parse(resultado.dezenas[12]),
                    int.Parse(resultado.dezenas[13]),
                    int.Parse(resultado.dezenas[14]),

                    valorAposta
                ) ;

            return concurso;
        }

        public IList<Premiacao> ConverterPremiacaoLotofacil(ResultadoLotofacilDTO.Response resultado)
        {
            var premiacoes = new List<Premiacao>();

            foreach (var premiacao in resultado.premiacoes)
            {
                premiacoes.Add(
                    new Premiacao(

                    )
            }

            return premiacoes;
        }

        public ResultadoLotofacil? ConverterResultadoLotofacail(ResultadoLotofacilDTO.Response resultado)
        {
            if(resultado is not null)
            {
                Concurso concurso = ConverterConcunsoLotocafil(resultado);
                List<Premiacao> premiacoes = 

                var retorno = new ResultadoLotofacil(
                        concurso,

                    );


                return retorno;
            }

            return null;            
        }     
        
        private EPremiacaoAcertos ObterEPremiacaoAcertos (string pontos)
        {
            EPremiacaoAcertos ePremiacaoAcertos = pontos switch
            {
                PremiacaoAcertos.QUINZE_PONTOS => EPremiacaoAcertos.QuinzePontos,
                PremiacaoAcertos.QUATOZE_PONTOS => EPremiacaoAcertos.QuartozePontos,
                PremiacaoAcertos.TREZE_PONTOS => EPremiacaoAcertos.TrezePontos,
                PremiacaoAcertos.DOZE_PONTOS => EPremiacaoAcertos.DozePontos,
                _ => EPremiacaoAcertos.OnzePontos,
            };
            return ePremiacaoAcertos;
        }
    }
}
