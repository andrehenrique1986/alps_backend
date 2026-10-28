using ALPS.Domain.Interfaces.Repository;
using ALPS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using ALPS.Domain.Interfaces;

namespace ALPS.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    { 
        private readonly ALPSContext _context;

        public RepositoryBase(ALPSContext context) 
        { 
            _context = context;
        }

        public async Task Atualizar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Excluir(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task Inserir(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> ListarPorId(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }         
}
