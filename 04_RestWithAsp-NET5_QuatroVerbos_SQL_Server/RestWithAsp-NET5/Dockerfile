#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["RestWithAsp-NET5/RestWithAsp-NET5.csproj", "RestWithAsp-NET5/"]
RUN dotnet restore "RestWithAsp-NET5/RestWithAsp-NET5.csproj"
COPY . .
WORKDIR "/src/RestWithAsp-NET5"
RUN dotnet build "RestWithAsp-NET5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestWithAsp-NET5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestWithAsp-NET5.dll"]
