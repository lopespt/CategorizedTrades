using Core.Entity;

namespace Core.TradeCategoryRules;

public class MediumRiskRule : ITradeCategoryRule
{
    public bool Fulfills(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Public";
    }

    public string Name => "MEDIUMRISK";
}