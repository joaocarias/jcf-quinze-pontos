using System.ComponentModel.DataAnnotations;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class Concurso : EntidadeBase
    {
        [Required]
        public int Numero { get; private set; }

        [Required]
        public DateTime? DataRealizacao { get; private set; }

        [Required]
        public int Dezena1 { get; private set; }

        [Required]
        public int Dezena2 { get; private set; }

        [Required]
        public int Dezena3 { get; private set; }

        [Required]
        public int Dezena4 { get; private set; }

        [Required]
        public int Dezena5 { get; private set; }

        [Required]
        public int Dezena6 { get; private set; }

        [Required]
        public int Dezena7 { get; private set; }

        [Required]
        public int Dezena8 { get; private set; }

        [Required]
        public int Dezena9 { get; private set; }

        [Required]
        public int Dezena10 { get; private set; }

        [Required]
        public int Dezena11 { get; private set; }

        [Required]
        public int Dezena12 { get; private set; }

        [Required]
        public int Dezena13 { get; private set; }

        [Required]
        public int Dezena14 { get; private set; }

        [Required]
        public int Dezena15 { get; private set; }

        [Required]
        public decimal ValorAposta { get; private set; } 
    }
}
