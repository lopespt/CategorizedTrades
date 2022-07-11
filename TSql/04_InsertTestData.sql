SET NOCOUNT ON;
declare @privateSectorId int;
declare @publicSectorId int;

insert into dbo.ClientSectors(Name)
values ('Private');
set @privateSectorId = @@IDENTITY;
insert into dbo.ClientSectors(Name)
values ('Public');
set @publicSectorId = @@IDENTITY;

insert into dbo.Trades(value, ClientSectorId)
values (2000000, @privateSectorId),
    (400000, @publicSectorId),
    (500000, @publicSectorId),
    (3000000, @publicSectorId);
