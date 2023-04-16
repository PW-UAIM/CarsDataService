using Microsoft.AspNetCore.Mvc;

using majumi.CarService.CarsDataService.Logic;
using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;
using majumi.CarService.CarsDataService.Rest.Model.Services;
using majumi.CarService.CarsDataService.Rest.Model.Converters;
using majumi.CarService.CarsDataService.Rest.Model.Model;

namespace majumi.CarService.CarsDataService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class CarDataController : ControllerBase, ICarDataService, ITestsService
{
    private readonly ILogger<CarDataController> _logger;

    private readonly ICarCollection carCollection;

    public CarDataController(ILogger<CarDataController> logger)
    {
        _logger = logger;
        carCollection = new CarCollection();
    }

    [HttpGet]
    [Route("/car/{id:int}")]
    public ActionResult<CarData> GetCar(int id)
    {
        Car? car = carCollection.GetCarById(id);
        if (car == null)
            return NotFound();

        CarData carData = DataConverter.ConvertToCarData(car);
        return Ok(carData);
    }

    [HttpGet]
    [Route("/car/all")]
    public ActionResult<List<CarData>> GetAllCars()
    {
        List<Car> cars = carCollection.GetAllCars();
        List<CarData> carData = DataConverter.ConvertToCarDataList(cars);

        return Ok(carData);

    }

    [HttpGet]
    [Route("/car/all/client/{id:int}")]
    public ActionResult<List<CarData>> GetCarsByClient(int id)
    {
        List<Car>? cars = carCollection.GetCarsByClient(id);
        List<CarData> carData = DataConverter.ConvertToCarDataList(cars);

        return Ok(carData);
    }

    [HttpPost]
    [Route("/car/add")]
    public ActionResult<CarData> AddCar(Car car) 
    {
        Car? addedCar = carCollection.AddCar(car);
        if (addedCar == null)
            return UnprocessableEntity();
        CarData carData = DataConverter.ConvertToCarData(addedCar);

        return Created($"https://localhost:5000/car/get/{car.CarID}", carData);
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}