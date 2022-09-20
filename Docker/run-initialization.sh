# Wait to be sure that SQL Server came up
#!/bin/bash
sleep 90s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Sql.1234 -d master -i init.sql

#Tip: If you change any of the scripts after running in the first time you need to do a 
#docker-compose up --build to ensure that the container is built again or it will 
#just be using your old scripts.