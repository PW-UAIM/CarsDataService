using System.Text.Json;
using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Logic;

public class MechanicCollectionReader
{
    public static Mechanic[]? ReadFromJSON(string path)
    {
        return JsonSerializer.Deserialize<Mechanic[]>(File.ReadAllText(path));
    }
}
