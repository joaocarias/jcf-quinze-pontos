namespace Jcf.Client.LoteriaCaixa.Api.DTOs
{
    public class ResultadoLotofacilDTO
    {
        public class Request
        {

        }

        public class Response
        {
            public string loteria { get; set; }
            public string nome { get; set; }
            public int concurso { get; set; }
            public string data { get; set; }
            public string local { get; set; }
            public string[] dezenas { get; set; }
            public List<Premiaco> premiacoes { get; set; }
            public List<EstadosPremiado> estadosPremiados { get; set; }
            public bool acumulou { get; set; }
            public string acumuladaProxConcurso { get; set; }
            public string dataProxConcurso { get; set; }
            public int proxConcurso { get; set; }
            public string timeCoracao { get; set; }
            public int? mesSorte { get; set; }
        }

        public class Premiaco
        {
            public string acertos { get; set; }
            public int vencedores { get; set; }
            public string premio { get; set; }
        }

        public class EstadosPremiado
        {
            public string nome { get; set; }
            public string uf { get; set; }
            public string vencedores { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public List<object> cidades { get; set; }
        }
    }
}
