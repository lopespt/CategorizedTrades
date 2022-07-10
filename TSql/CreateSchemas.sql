DROP TABLE IF EXISTS Trades;
CREATE TABLE Trades(trade_id integer identity(1,1) primary key, value float(2), client_sector varchar(100));

