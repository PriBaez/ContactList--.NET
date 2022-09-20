# SQL Version 
FROM mcr.microsoft.com/mssql/server:2019-latest

WORKDIR /usr/src/app
USER root

COPY entrypoint.sh /usr/src/app
COPY run-initialization.sh /usr/src/app
COPY init.sql /usr/src/app

ENV SA_PASSWORD Sql.1234
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

EXPOSE 1433

RUN ["chmod", "+x", "/usr/src/app/entrypoint.sh"]
CMD /bin/bash ./entrypoint.sh