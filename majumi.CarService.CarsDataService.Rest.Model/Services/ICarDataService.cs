using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Rest.Model.Model;
using Microsoft.AspNetCore.Mvc;

namespace majumi.CarService.CarsDataService.Rest.Model.Services;

public interface ICarDataService
{
    public ActionResult<CarData> GetCar(int id);

    public ActionResult<List<CarData>> GetAllCars();

    public ActionResult<List<CarData>> GetCarsByClient(int id);

    public ActionResult<CarData> AddCar(Car car);
}
