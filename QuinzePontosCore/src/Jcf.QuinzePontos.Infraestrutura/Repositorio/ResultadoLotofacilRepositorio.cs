using Jcf.QuinzePontos.Dominio.Entidades;
using Jcf.QuinzePontos.Dominio.IRepositorios;
using Jcf.QuinzePontos.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infraestrutura.Repositorio
{
    public class ResultadoLotofacilRepositorio : IResultadoLotofacilRepositorio
    {
        private readonly AppDbContexto _appDbContexto;

        public ResultadoLotofacilRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<bool> AdicionarAsync(ResultadoLotofacil entity)
        {
            try
            {
                await _appDbContexto.ResultadosLotofacils.AddAsync(entity);
                await _appDbContexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ApagarAsync(ResultadoLotofacil entity)
        {
            try
            {
                entity.ApagarRegistro();
                _appDbContexto.ResultadosLotofacils.Update(entity);
                await _appDbContexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AtualizarAsync(ResultadoLotofacil entity)
        {
            try
            {
                 _appDbContexto.ResultadosLotofacils.Update(entity);
                await _appDbContexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IList<ResultadoLotofacil>>? ObtePorConcusroAsync(int numeroConcurso)
        {
            try
            {
                var lista = await _appDbContexto.ResultadosLotofacils
                    .Include(x => x.Concurso)
                    .Where(r => r.Concurso.Numero.Equals(numeroConcurso) && r.Ativo)
                    .AsNoTracking()
                    .ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                return new List<ResultadoLotofacil>();
            }
        }

        public async Task<ResultadoLotofacil>? ObterAsync(Guid id)
        {
            try
            {
                var retorno = await _appDbContexto.ResultadosLotofacils
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id.Equals(id));                    
                if(retorno is not null)
                {
                    return retorno;
                }

                return null;    
            }catch(Exception ex)
            {
                return null;
            }            
        }

        public async Task<IList<ResultadoLotofacil>>? ObteTodosAsync()
        {
            try
            {
                var lista = await _appDbContexto.ResultadosLotofacils
                    .Where(r => r.Ativo)
                    .AsNoTracking()
                    .ToListAsync();
                return lista;
            }catch (Exception ex)
            {
                return new List<ResultadoLotofacil>();
            }
        }
    }
}
