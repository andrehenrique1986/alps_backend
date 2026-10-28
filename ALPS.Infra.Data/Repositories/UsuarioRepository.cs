using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Infra.Data.Context;


namespace ALPS.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly ALPSContext _context;
        public UsuarioRepository(ALPSContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
