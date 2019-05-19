FROM microsoft/dotnet:2.2.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet AS build
WORKDIR /
COPY . .
RUN dotnet restore "Shortify/Shortify.csproj"
WORKDIR /Shortify
RUN dotnet build "Shortify.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Shortify.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT Docker
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shortify.dll"]