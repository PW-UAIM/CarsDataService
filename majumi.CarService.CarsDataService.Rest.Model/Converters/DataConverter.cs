using majumi.CarService.CarsDataService.Model;
using majumi.CarService.CarsDataService.Rest.Model.Model;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Reflection;

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
            Color = car.Color,
            Mileage = car.Mileage,
            Transmission = car.Transmission,
            FuelType = car.FuelType,
            EngineSize = car.EngineSize,
            Horsepower = car.Horsepower,
            Torque = car.Torque,
            Drivetrain = car.Drivetrain,
            SeatingCapacity = car.SeatingCapacity,
            VehicleType = car.VehicleType,
            Location = car.Location,
            VIN = car.VIN,
            LicensePlate = car.LicensePlate,
            Warranty = car.Warranty
        };
    }
}