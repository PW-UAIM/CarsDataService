using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Model.Services;

public interface ICarCollection
{
    public Car? GetCarById(int carID);
    public List<Car> GetCarsByClient(int clientID);
    public List<Car> GetAllCars();
    public Car? AddCar(Car car);
}

