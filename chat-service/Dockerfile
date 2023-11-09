FROM mcr.microsoft.com/dotnet/aspnet:7.0

EXPOSE 5207
WORKDIR /app
RUN dotnet restore
CMD [ "dotnet", "watch", "--non-interactive" ]
