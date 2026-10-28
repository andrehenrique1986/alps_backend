using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Domain.Interfaces.Services;


namespace ALPS.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository): base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }      
    }
}
