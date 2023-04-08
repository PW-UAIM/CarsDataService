using Microsoft.AspNetCore.Mvc;

using majumi.CarService.CarsDataService.Logic;
using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Model.Services;
using majumi.CarService.CarsDataService.Rest.Model.Services;

namespace majumi.CarService.CarsDataService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicDataController : ControllerBase, IMechanicDataService, ITestsService
{
    private readonly ILogger<MechanicDataController> _logger;

    private readonly IMechanicCollection mechanicCollection;

    public MechanicDataController(ILogger<MechanicDataController> logger)
    {
        _logger = logger;
        mechanicCollection = new MechanicCollection();
    }

    [HttpGet]
    [Route("/mechanic/{id:int}")]
    public Mechanic GetMechanic(int id)
    {
        return mechanicCollection.GetById(id);
    }

    [HttpGet]
    [Route("/allMechanics")]
    public Mechanic[] GetAllMechanics()
    {
        return mechanicCollection.GetAllMechanics();
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}