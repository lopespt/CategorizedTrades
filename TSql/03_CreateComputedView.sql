CREATE OR ALTER VIEW dbo.TradesComputed AS
    SELECT T.TradeId, 
           T.ClientSectorId, 
           T.Value,
           CS.Name as SectorName,
           dbo.ClassifyTradesFunction(TradeId) AS Risk 
    FROM Trades T
LEFT JOIN dbo.ClientSectors CS on CS.ClientSectorId = T.ClientSectorId