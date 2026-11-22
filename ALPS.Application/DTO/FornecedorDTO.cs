using ALPS.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ALPS.Application.DTO
{
    public class FornecedorDTO
    {
        public int FornecedorId { get; set; }
        [Required(ErrorMessage = "O campo Nome do Fornecedor é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Nome do Fornecedor deve ter no máximo 200 caracteres.")]
        public string FornecedorNome { get; set; }
        [Required(ErrorMessage = "O campo Nome Fantasia do Fornecedor é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Nome Fantasia do Fornecedor deve ter no máximo 200 caracteres.")]
        public string FornecedorNomeFantasia { get; set; }
        [Required(ErrorMessage = "O campo Número Fiscal do Fornecedor é obrigatório.")]
        public NumeroFiscal FornecedorNumeroFiscal { get; set; }
        [Required(ErrorMessage = "O campo Endereço do Fornecedor é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O campo Endereço do Fornecedor deve ter no máximo 300 caracteres.")]
        public string FornecedorEndereco { get; set; }
        [Required(ErrorMessage = "O campo Telefone do Fornecedor é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo Telefone do Fornecedor deve ter no máximo 20 caracteres.")]
        public string FornecedorTelefone { get; set; }
        [Required(ErrorMessage = "O campo E-mail do Fornecedor é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail do Fornecedor deve ser um endereço de e-mail válido.")]
        [MaxLength(200, ErrorMessage = "O campo E-mail do Fornecedor deve ter no máximo 200 caracteres.")]
        public string FornecedorEmail { get; set; }
        [Required(ErrorMessage = "O campo Status do Fornecedor é obrigatório.")]
        public bool FornecedorAtivo { get; set; }
        [Required(ErrorMessage = "O campo Data de Criação do Fornecedor é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo Data de Criação do Fornecedor deve ser uma data e hora válida.")]
        public DateTime FornecedorDataCriacao { get; set; }
    }
}
