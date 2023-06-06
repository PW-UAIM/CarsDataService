#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.CarService.CarsDataService.Model/majumi.CarService.CarsDataService.Model.csproj", "majumi.CarService.CarsDataService.Model/"]
COPY ["majumi.CarService.CarsDataService.Rest/majumi.CarService.CarsDataService.Rest.csproj", "majumi.CarService.CarsDataService.Rest/"]
COPY ["majumi.CarService.CarsDataService.Rest.Model/majumi.CarService.CarsDataService.Rest.Model.csproj", "majumi.CarService.CarsDataService.Rest.Model/"]
COPY ["majumi.CarService.CarsDataService.Rest.Tests/majumi.CarService.CarsDataService.Rest.Tests.csproj", "majumi.CarService.CarsDataService.Rest.Tests/"]
RUN dotnet restore "majumi.CarService.CarsDataService.Rest/majumi.CarService.CarsDataService.Rest.csproj"
COPY . .
WORKDIR "/src/majumi.CarService.CarsDataService.Rest"
RUN dotnet build "majumi.CarService.CarsDataService.Rest.csproj" -c Production -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.CarService.CarsDataService.Rest.csproj" -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.CarService.CarsDataService.Rest.dll"]