namespace Core;

public class TradeCategoryClassifier : ITradeCategoryClassifier
{
    private IList<ITradeCategoryRule> rules = new List<ITradeCategoryRule>();

    public void addRule(ITradeCategoryRule rule)
    {
        rules.Add(rule);
    }    
    
    
    public string Classify(ITrade trade)
    {
        foreach (var rule in rules)
            if (rule.Fulfills(trade))
                return rule.Name;

        throw new UndefinedCategoryException(trade);
    }
    
    public List<string> ClassifyAll(List<ITrade> portfolio)
    {
        return portfolio.ConvertAll(Classify);
    }
    
}

