namespace Core;

public interface ITradeCategoryClassifier
{
    string Classify(ITrade trade);
    List<string> ClassifyAll(List<ITrade> portfolio);
}