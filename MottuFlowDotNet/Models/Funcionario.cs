namespace MottuFlowApi.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;           // corresponde ao campo email
        public string Senha { get; set; } = null!;
        public string? RefreshToken { get; set; }           // corresponde ao refresh_token
        public DateTime? ExpiracaoRefreshToken { get; set; } // corresponde ao expiracao_refresh_token
    }
}
