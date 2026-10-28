using ALPS.Application.AppServices.Interfaces;
using ALPS.Domain.Interfaces.Services;


namespace ALPS.Application.AppServices.Services
{
    public class AppServiceBase<TEntity>: IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public async Task Atualizar(TEntity entity)
        {
            await _serviceBase.Atualizar(entity);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _serviceBase.Excluir(id);
        }

        public async Task Inserir(TEntity entity)
        {
            await _serviceBase.Inserir(entity);
        }

        public async Task<TEntity> ListarPorId(int id)
        {
            return await _serviceBase.ListarPorId(id);
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await _serviceBase.ListarTodos();
        }
    }
}
