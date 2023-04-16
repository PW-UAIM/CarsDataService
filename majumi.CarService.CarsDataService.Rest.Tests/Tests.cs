using System.Diagnostics;
using System.Text.Json;
using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;
using majumi.CarService.CarsDataService.Rest.Model.Model;
using majumi.CarService.CarsDataService.Rest.Model.Services;
using majumi.CarService.CarsDataService.Logic;

namespace majumi.CarService.CarsDataService.Rest.Tests;
public class Tests : ITestsService
{
    private static readonly HttpClient httpClient = new();

    public string RunTests(string host, int port)
    {
        throw new NotImplementedException();
    }
}

