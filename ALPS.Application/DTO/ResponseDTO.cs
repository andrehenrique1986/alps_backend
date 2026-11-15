namespace ALPS.Application.DTO
{
    public class ResponseDTO<TEntity>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public TEntity Dados { get; set; }
    }
}
