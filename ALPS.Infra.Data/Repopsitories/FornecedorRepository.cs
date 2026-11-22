using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Infra.Data.Context;
namespace ALPS.Infra.Data.Repopsitories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        private readonly ALPSDbContext _context;

        public FornecedorRepository(ALPSDbContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
