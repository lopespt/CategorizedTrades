CREATE OR ALTER FUNCTION dbo.ClassifyTradesFunction
    (@tradeId INT)
    RETURNS varchar(15)
AS
BEGIN
    DECLARE @value money
    DECLARE @clientSector varchar(50)
    DECLARE @result varchar(15) = ''
    SELECT @value = Value, @clientSector=CS.Name from dbo.Trades
    LEFT JOIN dbo.ClientSectors CS ON CS.ClientSectorId = Trades.ClientSectorId
    WHERE TradeId=@tradeId
    
    IF @value < 1000000.0 AND @clientSector='Public'
        set @result='LOWRISK'
    
    IF @value > 1000000.0 AND @clientSector='Public'
        set @result='MEDIUMRISK'

    IF @value > 1000000.0 AND @clientSector='Private'
        set @result='HIGHRISK'
    
    RETURN @result
END

