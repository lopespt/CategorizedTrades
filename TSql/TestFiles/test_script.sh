#bin/bash

sqlExecFile() {
  echo "executing sqlcmd $1" 
  if ! /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P root@123 -b -i $1; then
    echo "ERROR executing script $1" 
  fi 2> /dev/null;
}
  
sqlExecFile /tmp/TSql/CreateSchemas.sql
sqlExecFile /tmp/TSql/TradesClassifierProcedure.sql
sqlExecFile /tmp/TSql/TestFiles/TestTradesClassifierProcedure.sql
