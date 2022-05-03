using Jcf.QuinzePontos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infraestrutura.Contextos
{
    public class AppDbContexto : DbContext
    {
        public AppDbContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Concurso> Concursos { get; set; }

        public DbSet<CidadePremiada> CidadesPremiadas { get; set; }

        public DbSet<EstadoPremiado> EstadosPremiados { get; set; }

        public DbSet<Premiacao> Premiacoes { get; set; }

        public DbSet<ResultadoLotofacil> ResultadosLotofacils { get; set; }
    }
}
