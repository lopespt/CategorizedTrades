namespace Core.Rules;

public class LowRiskRule : ITradeCategoryRule
{
    public bool Fulfills(ITrade trade)
    {
        return trade.Value < 1000000 && trade.ClientSector == "Public";
    }

    public string Name => "LOWRISK";
}