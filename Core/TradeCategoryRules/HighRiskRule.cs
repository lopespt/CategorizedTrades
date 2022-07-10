namespace Core.Rules;

public class HighRiskRule : ITradeCategoryRule
{
    public bool fulfills(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Private";
    }

    public string name => "HIGHRISK";
}