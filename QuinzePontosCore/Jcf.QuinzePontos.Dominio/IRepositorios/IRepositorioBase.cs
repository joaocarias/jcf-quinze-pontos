namespace Jcf.QuinzePontos.Dominio.IRepositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<IList<T>>? ObteTodosAsync();
        Task<T>? ObterAsync(Guid id);
        Task<bool> AdicionarAsync(T entity);
        Task<bool> AtualizarAsync(T entity);
        Task<bool> ApagarAsync(T entity);
    }
}
