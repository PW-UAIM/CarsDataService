﻿using majumi.CarService.CarsDataService.Model;

namespace majumi.CarService.CarsDataService.Rest.Model.Services;

public interface ICarDataService
{
    public Car GetCar(int carID);

    public Car[] GetAllCars();
}