public class LocalidadeDTO
{
    public int IdLocalidade { get; set; }
    public DateTime DataHora { get; set; }
    public int IdMoto { get; set; }
    public int IdPatio { get; set; }
    public string? PontoReferencia { get; set; }
    public int IdCamera { get; set; }
}

public class LocalidadeCreateUpdateDTO
{
    public DateTime DataHora { get; set; }
    public int IdMoto { get; set; }
    public int IdPatio { get; set; }
    public string? PontoReferencia { get; set; }
    public int IdCamera { get; set; }
}