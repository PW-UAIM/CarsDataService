using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Rest.Model.Services;

public interface IMechanicDataService
{
    public Mechanic GetMechanic(int mechanicID);

    public Mechanic[] GetAllMechanics();
}
