public class CameraDTO
{
    public int IdCamera { get; set; }
    public string? StatusOperacional { get; set; }
    public string? LocalizacaoFisica { get; set; }
    public int IdPatio { get; set; }
}

public class CameraCreateUpdateDTO
{
    public string? StatusOperacional { get; set; }
    public string? LocalizacaoFisica { get; set; }
    public int IdPatio { get; set; }
}
