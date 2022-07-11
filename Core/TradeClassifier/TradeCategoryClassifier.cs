using Core.Entity;
using Core.TradeCategoryRules;

namespace Core.TradeClassifier;

public class TradeCategoryClassifier : ITradeCategoryClassifier
{
    private readonly IList<ITradeCategoryRule> _rules;

    public TradeCategoryClassifier(IList<ITradeCategoryRule> rules)
    {
        _rules = rules;
    }
    
    public TradeCategoryClassifier()
    {
        _rules = new List<ITradeCategoryRule>();
    }

    public void AddRule(ITradeCategoryRule rule)
    {
        _rules.Add(rule);
    }    
    
    
    public string Classify(ITrade trade)
    {
        foreach (var rule in _rules)
            if (rule.Fulfills(trade))
                return rule.Name;

        throw new UndefinedCategoryException(trade);
    }
    
    public List<string> ClassifyAll(List<ITrade> portfolio)
    {
        return portfolio.ConvertAll(Classify);
    }
    
}

