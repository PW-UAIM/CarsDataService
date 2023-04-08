using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Model.Services;

public interface IMechanicCollection
{
    public Mechanic? GetById(int searchedID);
    public Mechanic[] GetAllMechanics();
}

