public class PatioDTO
    {
        public int IdPatio { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int CapacidadeMaxima { get; set; }
    }

public class PatioCreateUpdateDTO
{
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public int CapacidadeMaxima { get; set; }
}