using Core.Entity;

namespace Core.TradeCategoryRules;

public class HighRiskRule : ITradeCategoryRule
{
    public bool Fulfills(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Private";
    }

    public string Name => "HIGHRISK";
}