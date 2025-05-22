public class ArucoTagDTO
{
    public int IdTag { get; set; }
    public string? Codigo { get; set; }
    public int IdMoto { get; set; }
    public string? Status { get; set; }
}
public class ArucoTagCreateUpdateDTO
{
    public string? Codigo { get; set; }
    public int IdMoto { get; set; }
    public string? Status { get; set; }
}