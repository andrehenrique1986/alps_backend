using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Domain.Interfaces.Services;


namespace ALPS.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository) 
            : base(fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

    }
}
