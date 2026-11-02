using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPS.Infra.Data.Repopsitories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly ALPSDbContext _context;
        public UsuarioRepository(ALPSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
