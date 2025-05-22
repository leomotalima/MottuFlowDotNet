namespace MottuFlowApi.Models
{
    public class Status
    {
        public int IdStatus { get; set; }
        public int IdMoto { get; set; }
        public string TipoStatus { get; set; } = null!;
        public string? Descricao { get; set; }
        public DateTime DataStatus { get; set; } = DateTime.Now;
        public int IdFuncionario { get; set; }

        public Moto? Moto { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
