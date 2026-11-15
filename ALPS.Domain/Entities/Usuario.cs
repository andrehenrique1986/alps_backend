using ALPS.Domain.Validations;


namespace ALPS.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; private set; }
        public string UsuarioNome { get; private set; }
        public string UsuarioEmail { get; private set; }
        public NumeroFiscal UsuarioCPF { get; private set; }
        public string UsuarioSenhaHash { get; private set; }
        public bool UsuarioAtivo { get; private set; }
        public DateTime UsuarioDataCriacao { get; private set; }

        private Usuario() { }

        public Usuario(
            int usuarioId, 
            string usuarioNome, 
            string usuarioEmail, 
            NumeroFiscal usuarioCPF, 
            string usuarioSenhaHash, 
            bool usuarioAtivo 
            )
        {
            DomainExceptionValidation.When(usuarioId < 0, "O Id do usuário deve ser positivo");
            UsuarioId = usuarioId;
            ValidateDomain(
                usuarioNome, 
                usuarioEmail, 
                usuarioCPF, 
                usuarioSenhaHash, 
                usuarioAtivo    
                );
            DomainExceptionValidation.When(UsuarioDataCriacao > DateTime.Now, "A Data de Criação do usuário não pode ser no futuro");
            UsuarioDataCriacao = DateTime.Now;
        }

        public Usuario(
            string usuarioNome,
            string usuarioEmail,
            NumeroFiscal usuarioCPF,
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
                usuarioAtivo 
                );
            UsuarioDataCriacao = usuarioDataCriacao;
        }

        public void ValidateDomain(
                string usuarioNome,
                string usuarioEmail,
                NumeroFiscal usuarioCPF,
                string usuarioSenhaHash,
                bool usuarioAtivo            
            )
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(usuarioNome), "O Nome do Usuário é obrigatório.");
            DomainExceptionValidation.When(usuarioNome.Length > 200, "O Nome do Usuário deve ter no máximo 200 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(usuarioEmail), "O Email do Usuário é obrigatório.");
            DomainExceptionValidation.When(usuarioEmail.Length < 5 || usuarioEmail.Length > 200, 
                "O Email do Usuário deve ter no mínimo 5 caracteres e no máximo 200 caracteres.");
            DomainExceptionValidation.When(usuarioCPF == null, "O CPF do Usuário é obrigatório.");
            DomainExceptionValidation.When(!NumeroFiscal.IsCPFValid(usuarioCPF.Numero), "O CPF do Usuário é inválido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(usuarioSenhaHash), "A Senha do Usuário é obrigatória.");
            DomainExceptionValidation.When(usuarioSenhaHash.Length < 8 || usuarioSenhaHash.Length > 200, 
                "A Senha do Usuário deve ter no mínimo 8 caracteres e no máximo 200 caracteres.");
            

            UsuarioNome = usuarioNome;
            UsuarioEmail = usuarioEmail;
            UsuarioCPF = usuarioCPF;
            UsuarioSenhaHash = usuarioSenhaHash;
            UsuarioAtivo = usuarioAtivo;
        
        }
       
        public void Update(
            string usuarioNome,
            string usuarioEmail,
            NumeroFiscal usuarioCPF,
            string usuarioSenhaHash,
            bool usuarioAtivo     
            )
        {
            ValidateDomain(
                usuarioNome, 
                usuarioEmail, 
                usuarioCPF, 
                usuarioSenhaHash, 
                usuarioAtivo
                );
        }
    } 
}
