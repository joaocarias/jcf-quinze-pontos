using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class CidadePremiada : EntidadeBase
    {        
        [StringLength(100)]
        public string Nome { get; private set; }

        public int? Vencedores { get; private set; }

        [StringLength(30)]
        public string Latitude { get; private set; }

        [StringLength(30)]
        public string Longitude { get; private set; }

        public Guid EstadoPremiadoId { get; private set; }
               
        [ForeignKey(nameof(EstadoPremiadoId))]
        public EstadoPremiado EstadoPremiado { get; private set; }

        public CidadePremiada(string nome, int? vencedores, string latitude, string longitude) : base()
        {            
            Nome = nome;
            Vencedores = vencedores;
            Latitude = latitude;
            Longitude = longitude;
        }

        private CidadePremiada() { }
    }
}
