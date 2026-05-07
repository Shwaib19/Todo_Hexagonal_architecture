FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/Todo.Api/Todo.Api.csproj", "Todo.Api/"]
COPY ["src/Todo.Application/Todo.Application.csproj", "Todo.Application/"]
COPY ["src/Todo.Domain/Todo.Domain.csproj", "Todo.Domain/"]
COPY ["src/Todo.Infrastructure/Todo.Infrastructure.csproj", "Todo.Infrastructure/"]

RUN dotnet restore "Todo.Api/Todo.Api.csproj"

COPY src/ .
WORKDIR "/src/Todo.Api"
RUN dotnet publish "Todo.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Todo.Api.dll"]