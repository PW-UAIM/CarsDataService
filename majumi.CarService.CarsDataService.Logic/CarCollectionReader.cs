using System.Text.Json;
using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Logic;

public class CarCollectionReader
{
    public static Car[]? ReadFromJSON(string path)
    {
        return JsonSerializer.Deserialize<Car[]>(File.ReadAllText(path));
    }
}
