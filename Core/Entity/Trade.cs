namespace Core.Entity;

public class Trade : ITrade
{
    public double Value { get; set; } = 0;
    public string ClientSector { get; set; } = "";
}