print 'Dropping Tables'
DROP TABLE IF EXISTS dbo.Trades;
DROP TABLE IF EXISTS dbo.ClientSectors;
DROP TABLE IF EXISTS dbo.TradeRisks;

print 'Creating ClientSectors Table'
CREATE TABLE dbo.ClientSectors
(
    ClientSectorId integer identity (1,1) primary key,
    Name           varchar(50) not null
);

print 'Creating Trades Table'
CREATE TABLE dbo.Trades
(
    TradeId        integer identity (1,1) primary key,
    Value          money       not null,
    ClientSectorId int         not null references dbo.ClientSectors (ClientSectorId),
);



