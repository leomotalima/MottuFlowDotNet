namespace MottuFlowApi.Models
{
    public class Localidade
    {
        public int IdLocalidade { get; set; }
        public DateTime DataHora { get; set; }
        public int IdMoto { get; set; }
        public int IdPatio { get; set; }
        public string PontoReferencia { get; set; } = null!;
        public int IdCamera { get; set; }

        public Moto? Moto { get; set; }
        public Patio? Patio { get; set; }
        public Camera? Camera { get; set; }
    }
}
