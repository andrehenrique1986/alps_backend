using ALPS.Domain.Validations;

namespace ALPS.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; private set; }
        public string FornecedorNome { get; private set; }
        public string FornecedorNomeFantasia { get; private set; }
        public NumeroFiscal FornecedorNumeroFiscal { get; private set; }
        public string FornecedorEndereco { get; private set; }
        public string FornecedorTelefone { get; private set; }
        public string FornecedorEmail { get; private set; }
        public bool FornecedorAtivo { get; private set; }
        public DateTime FornecedorDataCriacao { get; private set; }

        private Fornecedor() { }

        public Fornecedor(
            int fornecedorId,
            string fornecedorNome,
            string fornecedorNomeFantasia,
            NumeroFiscal fornecedorNumeroFiscal,
            string fornecedorEndereco,
            string fornecedorTelefone,
            string fornecedorEmail,
            bool fornecedorAtivo,
            DateTime? fornecedorDataCriacao = null)
        {
            DomainExceptionValidation.When(fornecedorId < 0, "O Id do fornecedor deve ser positivo.");

            var dataCriacao = fornecedorDataCriacao ?? DateTime.UtcNow;
            DomainExceptionValidation.When(dataCriacao > DateTime.UtcNow, "A Data de Criação do fornecedor não pode ser no futuro.");

            FornecedorId = fornecedorId;
            FornecedorDataCriacao = dataCriacao;

            ValidateDomain(
                fornecedorNome,
                fornecedorNomeFantasia,
                fornecedorNumeroFiscal,
                fornecedorEndereco,
                fornecedorTelefone,
                fornecedorEmail,
                fornecedorAtivo);
        }

        public Fornecedor(
            string fornecedorNome,
            string fornecedorNomeFantasia,
            NumeroFiscal fornecedorNumeroFiscal,
            string fornecedorEndereco,
            string fornecedorTelefone,
            string fornecedorEmail,
            bool fornecedorAtivo = true,
            DateTime? fornecedorDataCriacao = null)
        {
            var dataCriacao = fornecedorDataCriacao ?? DateTime.UtcNow;
            DomainExceptionValidation.When(dataCriacao > DateTime.UtcNow, "A Data de Criação do fornecedor não pode ser no futuro.");

            FornecedorDataCriacao = dataCriacao;

            ValidateDomain(
                fornecedorNome,
                fornecedorNomeFantasia,
                fornecedorNumeroFiscal,
                fornecedorEndereco,
                fornecedorTelefone,
                fornecedorEmail,
                fornecedorAtivo);
        }

        public void ValidateDomain(
            string fornecedorNome,
            string fornecedorNomeFantasia,
            NumeroFiscal fornecedorNumeroFiscal,
            string fornecedorEndereco,
            string fornecedorTelefone,
            string fornecedorEmail,
            bool fornecedorAtivo)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(fornecedorNome), "O Nome do fornecedor é obrigatório.");
            DomainExceptionValidation.When(fornecedorNome.Length > 200, "O Nome do fornecedor deve ter no máximo 200 caracteres.");

            DomainExceptionValidation.When(!string.IsNullOrEmpty(fornecedorNomeFantasia) && fornecedorNomeFantasia.Length > 200,
                "O Nome Fantasia do fornecedor deve ter no máximo 200 caracteres.");

            DomainExceptionValidation.When(fornecedorNumeroFiscal == null, "O Número Fiscal do fornecedor é obrigatório.");

            var documentoLimpo = new string((fornecedorNumeroFiscal?.Numero ?? string.Empty).Where(char.IsDigit).ToArray());
            DomainExceptionValidation.When(
                documentoLimpo.Length != 11 && documentoLimpo.Length != 14,
                "O Número Fiscal deve conter 11 dígitos (CPF) ou 14 dígitos (CNPJ).");

            // Ajuste os nomes dos métodos estáticos conforme o seu Value Object NumeroFiscal
            var documentoValido = (documentoLimpo.Length == 11 && NumeroFiscal.IsCPFValid(documentoLimpo))
                               || (documentoLimpo.Length == 14 && NumeroFiscal.IsCNPJValid(documentoLimpo));

            DomainExceptionValidation.When(!documentoValido, "O CPF ou CNPJ do fornecedor é inválido.");

            DomainExceptionValidation.When(!string.IsNullOrWhiteSpace(fornecedorEndereco) && fornecedorEndereco.Length > 300,
                "O Endereço do fornecedor deve ter no máximo 300 caracteres.");

            DomainExceptionValidation.When(!string.IsNullOrWhiteSpace(fornecedorTelefone) && fornecedorTelefone.Length > 20,
                "O Telefone do fornecedor deve ter no máximo 20 caracteres.");

            DomainExceptionValidation.When(!string.IsNullOrWhiteSpace(fornecedorEmail) && (fornecedorEmail.Length < 5 || fornecedorEmail.Length > 200),
                "O E-mail do fornecedor deve ter entre 5 e 200 caracteres.");

            FornecedorNome = fornecedorNome;
            FornecedorNomeFantasia = fornecedorNomeFantasia ?? string.Empty;
            FornecedorNumeroFiscal = fornecedorNumeroFiscal;
            FornecedorEndereco = fornecedorEndereco ?? string.Empty;
            FornecedorTelefone = fornecedorTelefone ?? string.Empty;
            FornecedorEmail = fornecedorEmail ?? string.Empty;
            FornecedorAtivo = fornecedorAtivo;
        }

        public void Update(
            string fornecedorNome,
            string fornecedorNomeFantasia,
            NumeroFiscal fornecedorNumeroFiscal,
            string fornecedorEndereco,
            string fornecedorTelefone,
            string fornecedorEmail,
            bool fornecedorAtivo)
        {
            ValidateDomain(
                fornecedorNome,
                fornecedorNomeFantasia,
                fornecedorNumeroFiscal,
                fornecedorEndereco,
                fornecedorTelefone,
                fornecedorEmail,
                fornecedorAtivo);
        }
    }
}