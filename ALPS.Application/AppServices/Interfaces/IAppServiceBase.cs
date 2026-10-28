namespace ALPS.Application.AppServices.Interfaces
{
     public interface IAppServiceBase<TEntity> where TEntity : class
     {
        Task Inserir(TEntity entity);
        Task<IEnumerable<TEntity>> ListarTodos();
        Task<TEntity> ListarPorId(int id);
        Task Atualizar(TEntity entity);
        Task<bool> Excluir(int id);
    }
}
