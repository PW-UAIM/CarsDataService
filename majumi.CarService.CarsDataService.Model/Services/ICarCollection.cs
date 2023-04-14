using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Model.Services;

public interface ICarCollection
{
    public Car? GetById(int searchedID);

    public Car[] GetAllCars();

    public Car[] GetCarsByClient(int id);

    public bool AddCar(Car car);
}

