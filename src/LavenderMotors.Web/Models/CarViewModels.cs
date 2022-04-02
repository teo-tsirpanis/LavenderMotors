using LavenderMotors.Entities;

namespace LavenderMotors.Web.Models;

public class CarListViewModel
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }
    public CarListViewModel()
    {

    }
    public CarListViewModel(Car car)
    {
        Brand = car.Brand;
        Model = car.Model;
        CarRegistrationNumber = car.CarRegistrationNumber;
    }
}

public class CarCreateViewModel
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }
    public CarCreateViewModel()
    {

    }
    public CarCreateViewModel(Car car)
    {
        Brand = car.Brand;
        Model = car.Model;
        CarRegistrationNumber = car.CarRegistrationNumber;

    }
}

public class CarUpdateViewModel
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }
    public CarUpdateViewModel()
    {

    }
    public CarUpdateViewModel(Car car)
    {
        Id = car.Id;
        Brand = car.Brand;
        Model = car.Model;
        CarRegistrationNumber = car.CarRegistrationNumber;
    }
}

public class CarFinishViewModel
{
    public Guid Id { get; set; }
    public CarFinishViewModel()
    {

    }
    public CarFinishViewModel(Car car)
    {
        Id = car.Id;
    }
}

public class CarDeleteViewModel
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarRegistrationNumber { get; set; }
    public CarDeleteViewModel()
    {

    }
    public CarDeleteViewModel(Car car)
    {
        Id = car.Id;
        Brand = car.Brand;
        Model = car.Model;
        CarRegistrationNumber = car.CarRegistrationNumber;

    }
}
