using ALPS.Application.AppServices.Interfaces;
using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Services;


namespace ALPS.Application.AppServices.Services
{
    public class AppUsuarioService : AppServiceBase<Usuario>, IAppUsuarioService
    {
        private readonly IUsuarioService _usuarioService;

        public AppUsuarioService(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }       
    }
}
