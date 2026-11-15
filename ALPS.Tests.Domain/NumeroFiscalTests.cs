using Xunit;
using ALPS.Domain.Entities;
using ALPS.Domain.Enums;
using ALPS.Domain.Validations;

namespace ALPS.Domain.Tests.Entities
{
    public class NumeroFiscalTests
    {
        [Theory]
        [InlineData("36167787867")] // CPF Válido (sem máscara)
        [InlineData("361.677.878-67")] // CPF Válido (com máscara) - Substitua por um CPF válido real para teste
        [InlineData("21.425.093/0001-76")] // CNPJ Válido do Banco do Brasil (exemplo clássico)
        public void CriarNumeroFiscal_ComDocumentoValido_DeveCriarComSucesso(string documento)
        {
            // Act
            var numeroFiscal = new NumeroFiscal(documento);

            // Assert
            Assert.NotNull(numeroFiscal);
            Assert.False(string.IsNullOrEmpty(numeroFiscal.Numero));
        }

        [Theory]
        [InlineData("12345678901")] // CPF com dígitos inválidos matematicamente
        [InlineData("11111111111")] // CPF com todos os dígitos iguais
        [InlineData("12.345.678/0001-99")] // CNPJ inválido
        [InlineData("123")] // Tamanho incorreto
        [InlineData("")] // Vazio
        [InlineData(null)] // Nulo
        public void CriarNumeroFiscal_ComDocumentoInvalido_DeveLancarExcecao(string documento)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new NumeroFiscal(documento));
        }

        [Fact(DisplayName = "Deve definir o tipo correto como CPF")]
        public void NumeroFiscal_DeveDefinirTipoCorretoComoCpf()
        {
            // Arrange & Act
            var numeroFiscal = new NumeroFiscal("52998224725"); // Exemplo de CPF

            // Assert
            Assert.Equal(TipoNumeroFiscal.CPF, numeroFiscal.Tipo);
        }

        [Fact(DisplayName = "Deve definir o tipo correto como CNPJ")]
        public void NumeroFiscal_DeveDefinirTipoCorretoComoCnpj()
        {
            // Arrange & Act
            var numeroFiscal = new NumeroFiscal("00000000000191"); // CNPJ do BB limpo

            // Assert
            Assert.Equal(TipoNumeroFiscal.CNPJ, numeroFiscal.Tipo);
        }
    }
}