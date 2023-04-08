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
            IMechanicCollection mechanicCollection = new MechanicCollection();

            Mechanic[] mechanics1 = mechanicCollection.GetAllMechanics();
            MechanicData[] mechanics2 = GetMechanics(host, (ushort)port);

            Debug.Assert(condition: mechanics1.Length == mechanics2.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
    }

    private MechanicData[] GetMechanics(string webServiceHost, ushort webServicePort)
    {
        string webServiceUri = string.Format("https://{0}:{1}/allMechanics", webServiceHost, webServicePort);

        Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        webServiceCall.Wait();

        string jsonResponseContent = webServiceCall.Result;

        MechanicData[] mechanics = ConvertJson(jsonResponseContent);

        return mechanics;
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

    public MechanicData[] ConvertJson(string json)
    {
        MechanicData[] mechanics = JsonSerializer.Deserialize<MechanicData[]>(json);

        return mechanics;
    }
}

