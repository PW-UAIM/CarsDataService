using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Rest.Model.Model;

namespace majumi.CarService.CarsDataService.Rest.Model.Converters;

public static class DataConverter
{
    public static CarData ConvertToCarData(this Car car)
    {
        return new CarData
        {
            CarID = car.CarID,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year,
            Mileage = car.Mileage,
            EngineSize = car.EngineSize,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            ClientID = car.ClientID
        };
    }

    public static List<CarData> ConvertToCarDataList(this List<Car> cars)
    {
        List<CarData> carData = new();

        foreach (Car v in cars)
        {
            carData.Add(ConvertToCarData(v));
        }

        return carData;
    }
}