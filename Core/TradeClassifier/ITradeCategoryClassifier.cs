using Core.Entity;

namespace Core.TradeClassifier;

public interface ITradeCategoryClassifier
{
    string Classify(ITrade trade);
    List<string> ClassifyAll(List<ITrade> portfolio);
}