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
        Debug.Assert(condition: port > 0);

        try
        {
            ICarCollection carCollection = new CarCollection();

            Car[] cars1 = carCollection.GetAllCars();
            CarData[] cars2 = GetCars(host, (ushort)port);

            Debug.Assert(condition: cars1.Length == cars2.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
    }

    private CarData[] GetCars(string webServiceHost, ushort webServicePort)
    {
        string webServiceUri = string.Format("https://{0}:{1}/allCars", webServiceHost, webServicePort);

        Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        webServiceCall.Wait();

        string jsonResponseContent = webServiceCall.Result;

        CarData[] cars = ConvertJson(jsonResponseContent);

        return cars;
    }

    public static async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

        return httpResponseContent;
    }

    public CarData[] ConvertJson(string json)
    {
        CarData[] cars = JsonSerializer.Deserialize<CarData[]>(json);

        return cars;
    }
}

