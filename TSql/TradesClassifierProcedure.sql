CREATE OR ALTER PROCEDURE TradeClassfier
AS 
    DECLARE @id int
    DECLARE @soma int
    
    set @soma=0
    
    DECLARE db_cursor CURSOR FOR 
    SELECT trade_id from Trades
    
    OPEN db_cursor
    FETCH NEXT FROM db_cursor INTO @id
    WHILE @@FETCH_STATUS = 0
    BEGIN
        set @soma = @soma+@id    
        FETCH NEXT FROM db_cursor into @id
        END
    
    CLOSE db_cursor;
    DEALLOCATE  db_cursor;
    return @soma
    ;
GO
declare @s int;
exec @s = TradeClassfier;
print @s;
go

