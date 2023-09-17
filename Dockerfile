FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY deploy/ ./
ENTRYPOINT ["dotnet", "Server.dll"]