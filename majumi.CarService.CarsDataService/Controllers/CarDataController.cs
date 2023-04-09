using Microsoft.AspNetCore.Mvc;

using majumi.CarService.CarsDataService.Logic;
using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;
using majumi.CarService.CarsDataService.Rest.Model.Services;

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
    public Car GetCar(int id)
    {
        return carCollection.GetById(id);
    }

    [HttpGet]
    [Route("/allCars")]
    public Car[] GetAllCars()
    {
        return carCollection.GetAllCars();
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}