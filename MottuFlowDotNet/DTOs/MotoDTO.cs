
public class MotoDTO
{
    public int IdMoto { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public string? Fabricante { get; set; }
    public int Ano { get; set; }
    public int IdPatio { get; set; }
    public string? LocalizacaoAtual { get; set; }
}

public class MotoCreateUpdateDTO
{
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public string? Fabricante { get; set; }
    public int Ano { get; set; }
    public int IdPatio { get; set; }
    public string? LocalizacaoAtual { get; set; }
}
