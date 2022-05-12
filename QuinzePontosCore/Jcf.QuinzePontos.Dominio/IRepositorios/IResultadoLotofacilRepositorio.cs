using Jcf.QuinzePontos.Dominio.Entidades;

namespace Jcf.QuinzePontos.Dominio.IRepositorios
{
    public interface IResultadoLotofacilRepositorio : IRepositorioBase<ResultadoLotofacil>
    {
        Task<IList<ResultadoLotofacil>> ObtePorConcusroAsync(int numeroConcurso);
    }
}
