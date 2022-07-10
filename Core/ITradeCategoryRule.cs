namespace Core;

public interface ITradeCategoryRule
{
    bool Fulfills(ITrade trade);
    string Name { get; }
}