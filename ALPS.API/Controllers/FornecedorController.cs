using ALPS.Application.AppServices.Interfaces;
using ALPS.Application.DTO;
using ALPS.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ALPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IAppFornecedorService _appFornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(
            IAppFornecedorService appFornecedorService, 
            IMapper mapper
            )
        {
            _appFornecedorService = appFornecedorService;
            _mapper = mapper;
        }

        [HttpPost("cadastrarNovoFornecedor")]
        public async Task<IActionResult> CriarNovoFornecedor([FromBody] FornecedorDTO fornecedorDTO)
        {
            try
            {
                // 1. Validação de nulo
                if (fornecedorDTO == null)
                {
                    return BadRequest(new ResponseDTO<FornecedorDTO>
                    {
                        Sucesso = false,
                        Mensagem = "O Fornecedor não pode ser nulo.",
                        Dados = null
                    });
                }

                // 2. Mapeia DTO para Entidade
                var fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);

                // 3. Insere no banco/serviço
                await _appFornecedorService.Inserir(fornecedor);

                // 4. Mapeia a entidade salva de volta para DTO para retornar ao cliente
                var fornecedorRetornoDto = _mapper.Map<FornecedorDTO>(fornecedor);

                // 5. Retorno de Sucesso
                return Ok(new ResponseDTO<FornecedorDTO>
                {
                    Sucesso = true,
                    Mensagem = "Fornecedor criado com sucesso.",
                    Dados = fornecedorRetornoDto
                });

            }
            catch (Exception ex)
            {

                var detalheInterno = ex.InnerException?.InnerException?.Message
                       ?? ex.InnerException?.Message
                       ?? ex.Message;
                // 6. Tratamento de exceções
                return StatusCode(500, new ResponseDTO<UsuarioDTO>
                {
                    Sucesso = false,
                    Mensagem = $"Ocorreu um erro ao criar o fornecedor: {detalheInterno}",
                    Dados = null
                });
            }
        }
    }
}
