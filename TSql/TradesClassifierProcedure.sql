CREATE OR ALTER PROCEDURE dbo.ClassifyTrades
AS
BEGIN
    -- Rule for LowRisk Trades
    UPDATE Trades
    SET TradeRiskId=(select top 1 TradeRiskId from TradeRisks where Name = 'LOWRISK')
    WHERE Value < 1000000
      AND ClientSectorId = (select top 1 ClientSectorId from dbo.ClientSectors where Name = 'Public')


    -- Rule for MediumRisk Trades
    UPDATE Trades
    SET TradeRiskId=(select top 1 TradeRiskId from TradeRisks where Name = 'MEDIUMRISK')
    WHERE Value > 1000000
      AND ClientSectorId = (select top 1 ClientSectorId from dbo.ClientSectors where Name = 'Public')

    
    -- Rule for HighRisk Trades
    UPDATE Trades
    SET TradeRiskId=(select top 1 TradeRiskId from TradeRisks where Name = 'HIGHRISK')
    WHERE Value > 1000000
      AND ClientSectorId = (select top 1 ClientSectorId from dbo.ClientSectors where Name = 'Private')
END


    