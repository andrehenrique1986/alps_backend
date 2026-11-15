using ALPS.Application.AppServices.Interfaces;
using ALPS.Application.DTO;
using ALPS.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ALPS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAppUsuarioService _appUsuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(
            IAppUsuarioService appUsuarioService,
            IMapper mapper
        )
        {
            _appUsuarioService = appUsuarioService;
            _mapper = mapper;
        }

        [HttpPost("criarUsuario")]
        public async Task<IActionResult> CriarNovoUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                // 1. Validação de nulo
                if (usuarioDTO == null)
                {
                    return BadRequest(new ResponseDTO<UsuarioDTO>
                    {
                        Sucesso = false,
                        Mensagem = "O Usuário não pode ser nulo.",
                        Dados = null
                    });
                }

                // 2. Mapeia DTO para Entidade
                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                // 3. Insere no banco/serviço
                await _appUsuarioService.Inserir(usuario);

                // 4. Mapeia a entidade salva de volta para DTO para retornar ao cliente
                var usuarioRetornoDto = _mapper.Map<UsuarioDTO>(usuario);

             
                // 5. Retorno de Sucesso
                return Ok(new ResponseDTO<UsuarioDTO>
                {
                    Sucesso = true,
                    Mensagem = "Usuário criado com sucesso.",
                    Dados = usuarioRetornoDto
                });
            }
            catch (Exception ex)
            {
                // 6. Tratamento de exceções
                return StatusCode(500, new ResponseDTO<UsuarioDTO>
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao criar o usuário: {ex.Message}",
                    Dados = null
                });
            }
        }
    }
}