using System.Collections.Generic;
using Core.Entity;
using Core.TradeCategoryRules;
using Core.TradeClassifier;
using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Test]
    public void TestTradesCategorization()
    {
        var portfolio = new List<ITrade>
        {
            new Trade {Value = 2000000, ClientSector = "Private"},
            new Trade {Value = 400000, ClientSector = "Public"},
            new Trade {Value = 500000, ClientSector = "Public"},
            new Trade {Value = 3000000, ClientSector = "Public"},
        };

        var categoryRules = new ITradeCategoryRule[] {new HighRiskRule(), new MediumRiskRule(), new LowRiskRule()};
        TradeCategoryClassifier classifier = new TradeCategoryClassifier(categoryRules);

        var output = classifier.ClassifyAll(portfolio);

        Assert.AreEqual(new List<string> {"HIGHRISK", "LOWRISK", "LOWRISK", "MEDIUMRISK"}, output);
    }
    
    [Test]
    public void TestLowRiskTradeRule()
    {
        ITradeCategoryRule rule = new LowRiskRule();

        foreach (var trade in CreateLowRiskTrades()) 
            Assert.IsTrue(rule.Fulfills(trade));
        foreach (var trade in CreateMediumRiskTrades()) 
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in CreateHighRiskTrades()) 
            Assert.IsFalse(rule.Fulfills(trade));
    }
    
    [Test]
    public void TestMediumRiskTradeRule()
    {
        ITradeCategoryRule rule = new MediumRiskRule();
        foreach (var trade in CreateLowRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in CreateMediumRiskTrades())
            Assert.IsTrue(rule.Fulfills(trade));
        foreach (var trade in CreateHighRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
    }
    
    [Test]
    public void TestHighRiskTradeRule()
    {
        ITradeCategoryRule rule = new HighRiskRule();
        foreach (var trade in CreateLowRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in CreateMediumRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in CreateHighRiskTrades())
            Assert.IsTrue(rule.Fulfills(trade));
    }
    
    
    private IEnumerable<Trade> CreateLowRiskTrades()
    {
        yield return new Trade() {Value = 100, ClientSector = "Public"};
        yield return new Trade {Value = 80000, ClientSector = "Public"};
        yield return new Trade {Value = 999999, ClientSector = "Public"};
        yield return new Trade {Value = 1, ClientSector = "Public"};
    }
    
    private IEnumerable<Trade> CreateMediumRiskTrades()
    {
        yield return new Trade {Value = 1000001, ClientSector = "Public"};
        yield return new Trade {Value = 4123456, ClientSector = "Public"};
        yield return new Trade {Value = 5021654, ClientSector = "Public"};
    }
    
    private IEnumerable<Trade> CreateHighRiskTrades()
    {
        yield return new Trade {Value = 1000001, ClientSector = "Private"};
        yield return new Trade {Value = 4123456, ClientSector = "Private"};
        yield return new Trade {Value = 5021654, ClientSector = "Private"};
    }
}