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

        public Concurso(int numero, DateTime? dataRealizacao, int dezena1, int dezena2, int dezena3, int dezena4, int dezena5, int dezena6, int dezena7, int dezena8, int dezena9, int dezena10, int dezena11, int dezena12, int dezena13, int dezena14, int dezena15, decimal valorAposta) : base()
        {
            Numero = numero;
            DataRealizacao = dataRealizacao;
            Dezena1 = dezena1;
            Dezena2 = dezena2;
            Dezena3 = dezena3;
            Dezena4 = dezena4;
            Dezena5 = dezena5;
            Dezena6 = dezena6;
            Dezena7 = dezena7;
            Dezena8 = dezena8;
            Dezena9 = dezena9;
            Dezena10 = dezena10;
            Dezena11 = dezena11;
            Dezena12 = dezena12;
            Dezena13 = dezena13;
            Dezena14 = dezena14;
            Dezena15 = dezena15;
            ValorAposta = valorAposta;
        }

        private Concurso() { }
    }
}
