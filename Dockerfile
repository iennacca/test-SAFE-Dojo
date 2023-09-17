FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY deploy/ ./
ENTRYPOINT ["dotnet", "Server.dll"]

# Running on Docker
# Create the image
# docker build . --tag app-safe-dojo:latest
# Run the container
# docker run -p 8085:8085 app-safe-dojo:latest