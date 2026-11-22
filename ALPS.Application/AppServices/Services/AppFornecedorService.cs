using ALPS.Application.AppServices.Interfaces;
using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Services;

namespace ALPS.Application.AppServices.Services
{
    public class AppFornecedorService : AppServiceBase<Fornecedor>, IAppFornecedorService
    {
        private readonly IFornecedorService _fornecedorService;

        public AppFornecedorService(IFornecedorService fornecedorService) : base(fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }
    }
}