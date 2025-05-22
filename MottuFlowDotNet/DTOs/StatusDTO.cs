public class StatusDTO
{
    public int IdStatus { get; set; }
    public int IdMoto { get; set; }
    public string? TipoStatus { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataStatus { get; set; }
    public int IdFuncionario { get; set; }
}

public class StatusCreateUpdateDTO
{
    public int IdMoto { get; set; }
    public string? TipoStatus { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataStatus { get; set; }
    public int IdFuncionario { get; set; }
}