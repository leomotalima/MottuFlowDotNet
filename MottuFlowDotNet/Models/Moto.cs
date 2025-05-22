namespace MottuFlowApi.Models
{
    public class Moto
    {
        public int IdMoto { get; set; }
        public string Placa { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Fabricante { get; set; } = null!;
        public int Ano { get; set; }
        public int IdPatio { get; set; }
        public string LocalizacaoAtual { get; set; } = null!;

        public Patio? Patio { get; set; }
        public ICollection<ArucoTag>? ArucoTags { get; set; }
        public ICollection<Status>? Statuses { get; set; }
        public ICollection<Localidade>? Localidades { get; set; }
    }
}
