FROM microsoft/dotnet:2.1-sdk AS Build
WORKDIR /usr/src
COPY UI.csproj .
RUN dotnet restore
COPY . .
RUN dotnet build

FROM Build AS Publish
RUN dotnet publish -o /usr/published

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /usr/app
COPY --from=Publish /usr/published .
CMD ["dotnet", "UI.dll"]