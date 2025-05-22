namespace MottuFlowApi.Models
{
    public class Patio
    {
        public int IdPatio { get; set; }
        public string Nome { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public int CapacidadeMaxima { get; set; }

        public ICollection<Moto>? Motos { get; set; }
        public ICollection<Camera>? Cameras { get; set; }
        public ICollection<Localidade>? Localidades { get; set; }
    }
}
