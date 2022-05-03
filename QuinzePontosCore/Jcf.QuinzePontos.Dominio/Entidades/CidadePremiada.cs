﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Dominio.Entidades
{
    public class CidadePremiada : EntidadeBase
    {
        public Guid EstadoPremiadoId { get; set; }

        [ForeignKey(nameof(EstadoPremiadoId))]
        public EstadoPremiado EstadoPremiado { get; set; }

        public string Nome { get; private set; }

        public int? Vencedores { get; private set; }

        public double? Latitude { get; private set; }
        
        public double? Longitude { get; private set; }
    }
}
