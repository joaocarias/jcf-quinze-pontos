using System.ComponentModel.DataAnnotations;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class EntidadeBase
    {
        [Required]
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public DateTime DataCadastro { get; private set; }

        public DateTime? DataAlteracao { get; private set; } = null;

        [Required]
        public bool Ativo { get; private set; } = true;

        public void ApagarRegistro()
        {
            DataAlteracao = DateTime.Now;
            Ativo = false; 
        }

    }
}
