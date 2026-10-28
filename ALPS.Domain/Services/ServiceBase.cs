using ALPS.Domain.Interfaces.Repository;
using ALPS.Domain.Interfaces.Services;


namespace ALPS.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Atualizar(TEntity entity)
        {
            await _repository.Atualizar(entity);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repository.Excluir(id);
        }

        public async Task Inserir(TEntity entity)
        {
            await _repository.Inserir(entity);
        }

        public async Task<TEntity> ListarPorId(int id)
        {
            return await _repository.ListarPorId(id);
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await _repository.ListarTodos();
        }
    }
}
