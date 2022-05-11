using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class EstadoPremiado : EntidadeBase
    {
        [StringLength(100)]
        public string Nome { get; private set; }

        [StringLength(2)]
        public string Uf { get; private set; }

        public int? Vencedores { get; private set; }

        public double? Latitude { get; private set; }

        public double? Longitude { get; private set; }

        public IList<CidadePremiada> Cidades { get; private set; }

        public Guid ResultadoLotofacilId { get; private set; }

        [ForeignKey(nameof(ResultadoLotofacilId))]
        public ResultadoLotofacil ResultadoLotofacil { get; private set; }

        public EstadoPremiado(string nome, string uf, int? vencedores, double? latitude, double? longitude, IList<CidadePremiada> cidades, ResultadoLotofacil resultadoLotofacil) : base()
        {
            Nome = nome;
            Uf = uf;
            Vencedores = vencedores;
            Latitude = latitude;
            Longitude = longitude;
            Cidades = cidades;
            ResultadoLotofacil = resultadoLotofacil;
            ResultadoLotofacilId = resultadoLotofacil?.Id ?? Guid.Empty;
        }
    }
}
