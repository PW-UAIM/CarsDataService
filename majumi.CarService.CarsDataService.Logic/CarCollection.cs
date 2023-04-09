using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;

namespace majumi.CarService.CarsDataService.Logic;

public class CarCollection : ICarCollection
{
    private static readonly List<Car> Cars;

    private static readonly object CarLock = new();
    static CarCollection()
    {
        Cars = new List<Car>(CarCollectionReader.ReadFromJSON("Cars.json"));
    }

    public Car? GetById(int searchedId)
    {
        lock (CarLock)
        {
            return Cars.Find(car => car.CarID == searchedId);
        }
    }

    public Car[] GetAllCars()
    {
        lock (CarLock)
        {
            return Cars.ToArray();
        }
    }
}