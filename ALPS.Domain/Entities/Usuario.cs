using ALPS.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPS.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; private set; }
        public string UsuarioNome { get; private set; }
        public string UsuarioEmail { get; private set; }
        public string UsuarioCPF { get; private set; }
        public string UsuarioSenhaHash { get; private set; }
        public bool UsuarioAtivo { get; private set; }
        public DateTime UsuarioDataCriao { get; private set; }

        private Usuario() { }

        public Usuario(
            int usuarioId, 
            string usuarioNome, 
            string usuarioEmail, 
            string usuarioCPF, 
            string usuarioSenhaHash, 
            bool usuarioAtivo, 
            DateTime usuarioDataCriao
            )
        {
            DomainExceptionValidation.When(usuarioId < 0, "O Id do usuário deve ser positivo");
            UsuarioId = usuarioId;
            ValidateDomain(
                usuarioNome, 
                usuarioEmail, 
                usuarioCPF, 
                usuarioSenhaHash, 
                usuarioAtivo,
                usuarioDataCriao
                );
        }

        public Usuario(
            string usuarioNome,
            string usuarioEmail,
            string usuarioCPF,
            string usuarioSenhaHash,
            bool usuarioAtivo,
            DateTime usuarioDataCriacao
            )
        {
            ValidateDomain(
                usuarioNome, 
                usuarioEmail, 
                usuarioCPF, 
                usuarioSenhaHash, 
                usuarioAtivo,
                usuarioDataCriacao
                );
        }    
    
    public void ValidateDomain(
            string usuarioNome,
            string usuarioEmail,
            string usuarioCPF,
            string usuarioSenhaHash,
            bool usuarioAtivo,
            DateTime usuarioDataCriacao
        )
        {
            UsuarioNome = usuarioNome;
            UsuarioEmail = usuarioEmail;
            UsuarioCPF = usuarioCPF;
            UsuarioSenhaHash = usuarioSenhaHash;
            UsuarioAtivo = usuarioAtivo;
            UsuarioDataCriao = usuarioDataCriacao;
        }

        public void Update(
            string usuarioNome,
            string usuarioEmail,
            string usuarioCPF,
            string usuarioSenhaHash,
            bool usuarioAtivo,
            DateTime usuarioDataCriacao
            )
        {
            ValidateDomain(
                usuarioNome, 
                usuarioEmail, 
                usuarioCPF, 
                usuarioSenhaHash, 
                usuarioAtivo,
                usuarioDataCriacao
                );
        }
    } 
}
