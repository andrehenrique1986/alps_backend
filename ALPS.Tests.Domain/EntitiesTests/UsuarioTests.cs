using ALPS.Domain.Entities;
using Xunit;

namespace ALPS.Tests.Domain.EntitiesTests
{
    public class UsuarioTests
    {
        [Fact(DisplayName = "Deve criar um usuário válido")]
        public void Usuario_CriarComDadosValidos_DeveRetornarInstanciaValida()
        {
            var dataEsperada = new DateTime(2026, 11, 1, 10, 0, 0);
            var usuario = new Usuario(
                "André Henrique", 
                "andre.lima@gmail.com",
                "36167787867",
                "Andre@2025",
                true,
                dataEsperada);

            Assert.NotNull(usuario);
            Assert.Equal("André Henrique", usuario.UsuarioNome);
            Assert.Equal("andre.lima@gmail.com", usuario.UsuarioEmail);
            Assert.Equal("36167787867", usuario.UsuarioCPF);
            Assert.Equal("Andre@2025", usuario.UsuarioSenhaHash);
            Assert.True(usuario.UsuarioAtivo);
            Assert.Equal(dataEsperada, usuario.UsuarioDataCriacao);
        }
    }
}
