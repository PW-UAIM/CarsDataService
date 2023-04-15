using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Rest.Model.Services;

public interface ICarDataService
{
    public Car GetCar(int carID);

    public Car[] GetAllCars();

    public Car[] GetCarsByClient(int clientID);

    public bool AddCar(Car car);

    public string RunTests(string host, int port);
}
