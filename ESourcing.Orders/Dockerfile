#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ESourcing.Orders/ESourcing.Orders.csproj", "ESourcing.Orders/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
COPY ["Ordering.Application/Ordering.Application.csproj", "Ordering.Application/"]
COPY ["OrderingDomain/Ordering.Domain.csproj", "OrderingDomain/"]
COPY ["Ordering.Infrasructure/Ordering.Infrasructure.csproj", "Ordering.Infrasructure/"]
RUN dotnet restore "ESourcing.Orders/ESourcing.Orders.csproj"
COPY . .
WORKDIR "/src/ESourcing.Orders"
RUN dotnet build "ESourcing.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESourcing.Orders.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESourcing.Orders.dll"]