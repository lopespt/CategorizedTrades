#bin/sh

containerName='sql_server_test'
docker run --name $containerName --rm -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=root@123" -p 1433:1433  -v ${PWD}:/tmp  -d mcr.microsoft.com/mssql/server:2022-latest > /dev/null  