namespace Auth.Infrastruture.CrossCutting.Exceptions;

public class AppSettings
{
    public string Secret { get; set; }
    public int ExpiracaoHoras { get; set; }
    public int PeriodoExperiencia { get; set; }
    public string Emissor { get; set; }
    public string ValidoEm { get; set; }
}

