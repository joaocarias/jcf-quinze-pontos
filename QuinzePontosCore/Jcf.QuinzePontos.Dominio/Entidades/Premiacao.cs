using Jcf.QuinzePontos.Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class Premiacao : EntidadeBase
    {
        public EPremiacaoAcertos PremiacaoAcerto { get; private set; }
     
        public int Vencedores { get; private set; }
        
        public decimal Premio { get; private set; }

        public Guid ResultadoLotofacilId { get; private set; }

        [ForeignKey(nameof(ResultadoLotofacilId))]
        public ResultadoLotofacil ResultadoLotofacil { get; private set; }

        public Premiacao(EPremiacaoAcertos premiacaoAcerto, int vencedores, decimal premio)
        {
            PremiacaoAcerto = premiacaoAcerto;
            Vencedores = vencedores;
            Premio = premio; 
        }

        private Premiacao() { }
    }
}
