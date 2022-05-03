using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class ResultadoLotofacil : EntidadeBase
    {                
        public Guid ConcursoId { get; private set; }

        [ForeignKey(nameof(ConcursoId))]
        public Concurso Concurso { get; private set; }

        public IList<Premiacao> Premiacoes { get; private set; }

        public IList<EstadoPremiado> EstadosPremiados { get; private set; }

        public bool? Acumulou { get; private set; }

        [StringLength(50)]
        public string AcumuladaProxConcurso { get; private set; }

        public DateTime? DataProxConcurso { get; private set; }

        public int? ProxConcurso { get; private set; }
    }
}
