FROM mcr.microsoft.com/dotnet/sdk:7.0

EXPOSE 5207

WORKDIR /app

COPY . .

RUN dotnet restore

CMD [ "dotnet", "watch", "--non-interactive" ]
