using System.Collections.Generic;
using Core.Entity;
using Core.TradeCategoryRules;
using Core.TradeClassifier;
using NUnit.Framework;

namespace Tests;

public class Tests
{
    private IEnumerable<Trade> createLowRiskTrades()
    {
        yield return new Trade() {Value = 100, ClientSector = "Public"};
        yield return new Trade {Value = 80000, ClientSector = "Public"};
        yield return new Trade {Value = 999999, ClientSector = "Public"};
        yield return new Trade {Value = 1, ClientSector = "Public"};
    }
    
    private IEnumerable<Trade> createMediumRiskTrades()
    {
        yield return new Trade {Value = 1000001, ClientSector = "Public"};
        yield return new Trade {Value = 4123456, ClientSector = "Public"};
        yield return new Trade {Value = 5021654, ClientSector = "Public"};
    }
    
    private IEnumerable<Trade> createHighRiskTrades()
    {
        yield return new Trade {Value = 1000001, ClientSector = "Private"};
        yield return new Trade {Value = 4123456, ClientSector = "Private"};
        yield return new Trade {Value = 5021654, ClientSector = "Private"};
    }
    
    [Test]
    public void TestLowRiskTradeRule()
    {
        ITradeCategoryRule rule = new LowRiskRule();

        foreach (var trade in createLowRiskTrades()) 
            Assert.IsTrue(rule.Fulfills(trade));
        foreach (var trade in createMediumRiskTrades()) 
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in createHighRiskTrades()) 
            Assert.IsFalse(rule.Fulfills(trade));
    }
    
    [Test]
    public void TestMediumRiskTradeRule()
    {
        ITradeCategoryRule rule = new MediumRiskRule();
        foreach (var trade in createLowRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in createMediumRiskTrades())
            Assert.IsTrue(rule.Fulfills(trade));
        foreach (var trade in createHighRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
    }
    
    [Test]
    public void TestHighRiskTradeRule()
    {
        ITradeCategoryRule rule = new HighRiskRule();
        foreach (var trade in createLowRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in createMediumRiskTrades())
            Assert.IsFalse(rule.Fulfills(trade));
        foreach (var trade in createHighRiskTrades())
            Assert.IsTrue(rule.Fulfills(trade));
    }


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

        TradeCategoryClassifier classifier = new TradeCategoryClassifier();
        
        classifier.AddRule(new HighRiskRule());
        classifier.AddRule(new MediumRiskRule());
        classifier.AddRule(new LowRiskRule());

        var output = classifier.ClassifyAll(portfolio);

        Assert.AreEqual(new List<string> {"HIGHRISK", "LOWRISK", "LOWRISK", "MEDIUMRISK"}, output);
    }
}