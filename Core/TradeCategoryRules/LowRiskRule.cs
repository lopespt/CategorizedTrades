namespace Core.Rules;

public class LowRiskRule : ITradeCategoryRule
{
    public bool fulfills(ITrade trade)
    {
        return trade.Value < 1000000 && trade.ClientSector == "Public";
    }

    public string name => "LOWRISK";
}