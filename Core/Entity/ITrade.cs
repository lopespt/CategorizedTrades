namespace Core.Entity;

public interface ITrade
{
    public double Value { get; }
    public string ClientSector { get; }
}