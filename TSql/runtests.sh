#bin/sh

containerName='sql_server_test'

docker run --name $containerName --rm -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=root@123" -p 1433:1433  -v ${PWD}:/tmp  -d mcr.microsoft.com/mssql/server:2022-latest > /dev/null
sleep 2
docker exec  $containerName bash /tmp/TSql/TestFiles/test_script.sh  
docker stop $containerName  > /dev/null

#exec dbo.ClassifyTrades;
#
#select *
#from Trades
#         left join dbo.ClientSectors CS on CS.ClientSectorId = Trades.ClientSectorId
#         left join dbo.TradeRisks TR on Trades.TradeRiskId = TR.TradeRiskId;
    