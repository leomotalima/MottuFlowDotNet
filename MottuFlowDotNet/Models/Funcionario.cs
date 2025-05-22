namespace MottuFlowApi.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
