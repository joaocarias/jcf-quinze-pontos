using Jcf.Client.LoteriaCaixa.Api.DTOs;
using Jcf.QuinzePontos.Dominio.Constantes;
using Jcf.QuinzePontos.Dominio.Entidades;
using Jcf.QuinzePontos.Dominio.Enums;
using Jcf.QuinzePontos.Dominio.IServicos;

namespace Jcf.QuinzePontos.Infraestrutura.Servicos
{
    public class ResultadoServico : IResultadoServico
    {
        public Concurso ConverterConcunsoLotocafil(ResultadoLotofacilDTO.Response resultado)
        {
            Concurso concurso = new(
                    resultado.concurso,
                    Convert.ToDateTime(resultado.data),

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

                    ObterValorAposta(resultado.premiacoes.FirstOrDefault(x => x.acertos.Equals(PremiacaoAcertos.ONZE_PONTOS)))
                );

            return concurso;
        }

        public IList<EstadoPremiado> ConverterEstadoPremiadoLotofacil(ResultadoLotofacilDTO.Response resultado)
        {
            var estados = new List<EstadoPremiado>();

            foreach(var estado in resultado.estadosPremiados)
            {
                estados.Add(
                    new EstadoPremiado(
                        estado.nome,
                        estado.uf,
                        int.Parse(estado.vencedores),
                        estado.latitude,
                        estado.longitude,
                        ObterCidades(estado)
                    )
                );
            }

            return estados;
        }

        public IList<Premiacao> ConverterPremiacaoLotofacil(ResultadoLotofacilDTO.Response resultado)
        {
            var premiacoes = new List<Premiacao>();

            foreach (var premiacao in resultado.premiacoes)
            {
                premiacoes.Add(
                    new Premiacao(
                        ObterEPremiacaoAcertos(premiacao.acertos),
                        premiacao.vencedores,
                        ConverterPremio(premiacao.premio)
                    )
                );
            }

            return premiacoes;
        }

        private decimal ConverterPremio(string premio)
        {
            try
            {
                var d = decimal.Parse(premio);
                return d;
            }
            catch (Exception ex)
            {
                return new decimal(0);
            }
        }

        public ResultadoLotofacil ConverterResultadoLotofacail(ResultadoLotofacilDTO.Response resultado)
        {
            Concurso concurso = ConverterConcunsoLotocafil(resultado);
            List<Premiacao> premiacoes = ConverterPremiacaoLotofacil(resultado).ToList();
            List<EstadoPremiado> estadoPremiados = ConverterEstadoPremiadoLotofacil(resultado).ToList();
            
            var retorno = new ResultadoLotofacil(
                    concurso,
                    resultado.local,
                    premiacoes,
                    estadoPremiados,
                    resultado.acumulou,
                    resultado.acumuladaProxConcurso,
                    !string.IsNullOrEmpty(resultado.dataProxConcurso) ? ConvertToDateTime(resultado.dataProxConcurso) : null,
                    resultado.proxConcurso
                );

            return retorno;
        }

        private EPremiacaoAcertos ObterEPremiacaoAcertos(string pontos)
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

        private decimal ObterValorAposta(ResultadoLotofacilDTO.Premiacao onzePontos)
        {
            try
            {
                decimal.TryParse(onzePontos.premio, out decimal valorAposta);
                var d = valorAposta / 2;
                return d;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private IList<CidadePremiada> ObterCidades(ResultadoLotofacilDTO.EstadoPremiado estadoPremiado)
        {
            var cidades = new List<CidadePremiada>();

            foreach (var c in estadoPremiado.cidades)
            {
                cidades.Add(
                    new CidadePremiada(
                        c.cidade,
                        int.Parse(c.vencedores),
                        c.latitude,
                        c.longitude
                    )
                 );
            }

            return cidades;
        }

        private DateTime? ConvertToDateTime(string data)
        {
            try
            {
                var d = Convert.ToDateTime(data);
                return d;
            }catch (Exception)
            {
                return null;
            }
        }

    }
}
