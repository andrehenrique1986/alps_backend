using ALPS.Domain.Entities;
using ALPS.Domain.Validations;
using Xunit;


namespace ALPS.Tests.Domain.EntitiesTests
{
    public class UsuarioTests
    {
        [Fact(DisplayName = "Deve criar um usuário válido com dados corretos")]
        public void Usuario_CriarComDadosValidos_DeveRetornarInstanciaValida()
        {
            // Arrange
            var dataEsperada = DateTime.Now;
            var cpfValido = new NumeroFiscal("36167787867"); // CPF válido para teste
            var senhaValida = "Andre@2025"; // Senha válida para teste

            // Act
            var usuario = new Usuario(
                "André Henrique",
                "andre.lima@gmail.com",
                cpfValido,
                senhaValida,
                true,
                dataEsperada);

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("André Henrique", usuario.UsuarioNome);
            Assert.Equal("andre.lima@gmail.com", usuario.UsuarioEmail);
            Assert.Equal("36167787867", usuario.UsuarioCPF.Numero);
            Assert.Equal("Andre@2025", usuario.UsuarioSenhaHash);
            Assert.True(usuario.UsuarioAtivo);
            Assert.Equal(dataEsperada, usuario.UsuarioDataCriacao);
        }

        [Fact(DisplayName = "Deve lançar exceção se o nome for vazio")]
        public void Usuario_NomeVazio_DeveLancarDomainException(string mensagemEsperada)
        {
            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Usuario(
                string.Empty,
                "andre.lima@gmail.com",
                new NumeroFiscal("36167787867"),
                "Andre@2025",
                true,
                DateTime.Now));

            Assert.Equal(mensagemEsperada, exception.Message);
        }

    }
}