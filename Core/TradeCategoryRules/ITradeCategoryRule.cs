using Core.Entity;

namespace Core.TradeCategoryRules;

public interface ITradeCategoryRule
{
    bool Fulfills(ITrade trade);
    string Name { get; }
}