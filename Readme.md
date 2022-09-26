A contact list made in C# with ASP.Net (MVC model)
The application was prove in docker with a single dockerfile 
and a docker-compose for the BD integration. 

IMPORTANT INFO: The connection string was modified for 
the Sql Server Container was able to communicate with the app container

In such cases you can run the app in the host and the BD in the container 
change the server from mssql-2019 to localhost. Otherwise, if you have the app and BD in your host machine (Sql Server Express, for example), change the server name 
to the server name in your host machine.