using ALPS.Application.AppServices.Services;
using ALPS.Domain.Entities;
using ALPS.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace ALPS.Tests.Application.AppServicesTests
{
    public class AppServiceBaseTests
    {
        private readonly Mock<IServiceBase<Usuario>> _serviceBaseMock;
        private readonly AppServiceBase<Usuario> _appServiceBase;

        public AppServiceBaseTests()
        {
            _serviceBaseMock = new Mock<IServiceBase<Usuario>>();
            _appServiceBase = new AppServiceBase<Usuario>(_serviceBaseMock.Object);
        }

        private static Usuario CriarUsuarioValido()
        {
            var cpf = new NumeroFiscal("36167787867");
            return new Usuario(
                "André Henrique",
                "andre.lima@yahoo.com.br",
                cpf,
                "$2a$11$hashExemploValidoParaTestes123456",
                true,
                DateTime.UtcNow
            );
        }

        [Fact(DisplayName = "Deve delegar Inserir para IServiceBase")]
        public async Task Inserir_DeveChamarServiceBaseInserir()
        {
            var usuario = CriarUsuarioValido();
            _serviceBaseMock
                .Setup(s => s.Inserir(usuario))
                .Returns(Task.CompletedTask);

            await _appServiceBase.Inserir(usuario);

            _serviceBaseMock.Verify(s => s.Inserir(usuario), Times.Once);
        }

        [Fact(DisplayName = "Deve delegar Atualizar para IServiceBase")]
        public async Task Atualizar_DeveChamarServiceBaseAtualizar()
        {
            var usuario = CriarUsuarioValido();
            _serviceBaseMock
                .Setup(s => s.Atualizar(usuario))
                .Returns(Task.CompletedTask);

            await _appServiceBase.Atualizar(usuario);

            _serviceBaseMock.Verify(s => s.Atualizar(usuario), Times.Once);
        }

        [Fact(DisplayName = "Deve retornar true ao excluir usuário existente")]
        public async Task Excluir_QuandoExistir_DeveRetornarTrue()
        {
            _serviceBaseMock
                .Setup(s => s.Excluir(1))
                .ReturnsAsync(true);

            var resultado = await _appServiceBase.Excluir(1);

            Assert.True(resultado);
            _serviceBaseMock.Verify(s => s.Excluir(1), Times.Once);
        }

        [Fact(DisplayName = "Deve retornar usuário por Id")]
        public async Task ListarPorId_QuandoExistir_DeveRetornarEntidade()
        {
            var usuario = CriarUsuarioValido();
            _serviceBaseMock
                .Setup(s => s.ListarPorId(1))
                .ReturnsAsync(usuario);

            var resultado = await _appServiceBase.ListarPorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(usuario.UsuarioEmail, resultado.UsuarioEmail);
            _serviceBaseMock.Verify(s => s.ListarPorId(1), Times.Once);
        }

        [Fact(DisplayName = "Deve listar todos os usuários")]
        public async Task ListarTodos_DeveRetornarListaDeEntidades()
        {
            var usuarios = new List<Usuario> { CriarUsuarioValido() };
            _serviceBaseMock
                .Setup(s => s.ListarTodos())
                .ReturnsAsync(usuarios);

            var resultado = (await _appServiceBase.ListarTodos()).ToList();

            Assert.Single(resultado);
            _serviceBaseMock.Verify(s => s.ListarTodos(), Times.Once);
        }
    }
}