FROM mcr.microsoft.com/mssql/server:2017-latest-ubuntu

ENV MSSQL_PID=Express
ENV SA_PASSWORD=159753!@
ENV ACCEPT_EULA=Y

EXPOSE 1433