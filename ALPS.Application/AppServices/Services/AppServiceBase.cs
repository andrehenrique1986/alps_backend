using ALPS.Application.AppServices.Interfaces;
using ALPS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPS.Application.AppServices.Services
{
    public class AppServiceBase<TEntity>: IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public Task Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Inserir(TEntity entity)
        {
            await _serviceBase.Inserir(entity);
        }

        public Task<TEntity> ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
