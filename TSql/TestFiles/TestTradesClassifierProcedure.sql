
-- SETUP

-- Inserting Testing Data
SET NOCOUNT ON;
declare @privateSectorId int;
declare @publicSectorId int;

insert into dbo.ClientSectors(Name)
values ('Private');
set @privateSectorId = @@IDENTITY;
insert into dbo.ClientSectors(Name)
values ('Public');
set @publicSectorId = @@IDENTITY;

insert into dbo.TradeRisks(Name, Description)
values ('LOWRISK', 'Trades with value less than 1,000,000 and client from Public Sector'),
       ('MEDIUMRISK', 'Trades with value greater than 1,000,000 and client from Public Sector'),
       ('HIGHRISK', 'Trades with value greater than 1,000,000 and client from Private Sector')

insert into dbo.Trades(value, ClientSectorId)
values (2000000, @privateSectorId),
       (400000, @publicSectorId),
       (500000, @publicSectorId),
       (3000000, @publicSectorId);


--TESTS
DECLARE @nullTrades integer=0;
SELECT @nullTrades = COUNT(*)
FROM Trades
where TradeRiskId is NULL;
IF @nullTrades != 4
    BEGIN
        RAISERROR ('ERROR: Num of NullTrades must be equals 4', 11, 1)
    END

exec ClassifyTrades;
SELECT @nullTrades = COUNT(*)
FROM Trades
where TradeRiskId is NULL;
IF @nullTrades != 0
        RAISERROR ('ERROR: there are unclassified trades', 11, 1)
ELSE
    PRINT 'AllTradesClassified TEST PASSED'

DECLARE @count int



-- LOWRISK TEST
SELECT @count = COUNT(*)
from Trades
         LEFT JOIN TradeRisks TR on Trades.TradeRiskId = TR.TradeRiskId
WHERE TradeId in (2, 3)
  AND TR.Name = 'LOWRISK'
IF @count != 2
    RAISERROR ('ERROR: Trades 2 and 3 should be classified as LOWRISK', 11, 1)
ELSE
    PRINT 'LOWRISK TEST PASSED'

-- MEDIUMRISK TEST
SELECT @count = COUNT(*)
from Trades
         LEFT JOIN TradeRisks TR on Trades.TradeRiskId = TR.TradeRiskId
WHERE TradeId in (4)
  AND TR.Name = 'MEDIUMRISK'
IF @count != 1
    RAISERROR ('ERROR: Trade 4 should be classified as MEDIUMRISK', 11, 1)
ELSE
    PRINT 'MEDIUMRISK TEST PASSED'

-- HIGHRISK TEST
SELECT @count = COUNT(*)
from Trades
         LEFT JOIN TradeRisks TR on Trades.TradeRiskId = TR.TradeRiskId
WHERE TradeId in (1)
  AND TR.Name = 'HIGHRISK'
IF @count != 1
    RAISERROR ('ERROR: Trade 1 should be classified as RIGHRISK', 11, 1)
ELSE
    PRINT 'HIGHRISK TEST PASSED'
