namespace Core.Rules;

public class MediumRiskRule : ITradeCategoryRule
{
    public bool fulfills(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Public";
    }

    public string name => "MEDIUMRISK";
}