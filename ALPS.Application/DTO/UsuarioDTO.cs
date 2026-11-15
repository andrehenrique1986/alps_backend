using ALPS.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace ALPS.Application.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O Nome do Usuário é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O Nome do Usuário deve ter no máximo 200 caracteres.")]
        public string UsuarioNome { get; set; }
        [Required(ErrorMessage = "O Email do Usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email do Usuário deve ser um endereço de email válido.")]
        [MinLength(5, ErrorMessage = "O Email do Usuário deve ter no mínimo 5 caracteres.")]
        [MaxLength(200, ErrorMessage = "O Email do Usuário deve ter no máximo 200 caracteres.")]
        public string UsuarioEmail { get; set; }
        [Required(ErrorMessage = "O CPF do Usuário é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF do Usuário deve conter exatamente 11 dígitos.")]
        [MaxLength(11, ErrorMessage = "O CPF do Usuário deve ter exatamente 11 caracteres.")]
        public string UsuarioCPF { get; set; }
        [Required(ErrorMessage = "A Senha do Usuário é obrigatória.")]
        [MinLength(8, ErrorMessage = "A Senha do Usuário deve ter no mínimo 8 caracteres.")]
        [MaxLength(200, ErrorMessage = "A Senha do Usuário deve ter no máximo 200 caracteres.")]
        public string UsuarioSenha { get; set; }
        [Required(ErrorMessage = "O Status do Usuário é obrigatório")]
        public bool UsuarioAtivo { get; set; }
        [Required(ErrorMessage = "A Data de Criação do Usuário é obrigatória")]
        [DataType(DataType.DateTime, ErrorMessage = "A Data de Criação do Usuário deve ser uma data e hora válida.")]
        public DateTime UsuarioDataCriacao { get; set; }

        public static implicit operator UsuarioDTO(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}
