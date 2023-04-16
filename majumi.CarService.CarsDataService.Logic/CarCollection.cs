using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;
using System.ComponentModel;

namespace majumi.CarService.CarsDataService.Logic;

public class CarCollection : ICarCollection
{
    private static readonly List<Car> Cars;

    private static readonly object CarLock = new();
    static CarCollection()
    {
        Cars = new List<Car>(CarCollectionReader.ReadFromJSON("Cars.json"));
    }
    private Car? FindByID(int carID)
    {
        foreach (Car car in Cars)
        {
            if (car.CarID == carID)
            {
                return car;
            }
        }

        return null;
    }

    public Car? GetCarById(int carID)
    {
        lock (CarLock)
        {
            return this.FindByID(carID);
        }
    }

    public List<Car> GetAllCars()
    {
        lock (CarLock)
        {
            return Cars;
        }
    }

    public List<Car> GetCarsByClient(int clientID)
    {
        lock (CarLock)
        {
            List<Car> cars = new();
            foreach (Car v in Cars)
            {
                if (v.ClientID == clientID)
                {
                    cars.Add(v);
                }
            }
            return cars;
        }
    }
    public Car? AddCar(Car car)
    {
        lock(CarLock)
        {
            Car? exisitingCar = FindByID(car.CarID);
            if (exisitingCar != null)
                return null;

            int lenBef = Cars.Count;
            Cars.Add(car);
            int lenAft = Cars.Count;

            if (lenBef >= lenAft)
                return null;

            return car;
        }
    }
}