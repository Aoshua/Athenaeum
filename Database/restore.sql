RESTORE DATABASE Athenaeum_DB 
FROM DISK='/var/opt/mssql/backup/Athenaeum_DB.bak' 
WITH MOVE 'Athenaeum_DB' TO '/var/opt/mssql/data/Athenaeum_DB.mdf', 
MOVE 'Athenaeum_DB_log' TO '/var/opt/mssql/data/Athenaeum_DB_log.ldf'