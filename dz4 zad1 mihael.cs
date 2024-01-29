using System;

abstract class Car
{
    public abstract void Drive();
}

public class Ford : Car
{
    public override void Drive()
    {
        Console.WriteLine("Driving a Ford");
    }
}

public class Toyota : Car
{
    public override void Drive()
    {
        Console.WriteLine("Driving a Toyota");
    }
}

abstract class CarFactory
{
    public abstract Car CreateCar();
}

public class FordFactory : CarFactory
{
    public override Car CreateCar()
    {
        return new Ford();
    }
}

public class ToyotaFactory : CarFactory
{
    public override Car CreateCar()
    {
        return new Toyota();
    }
}
class Client
{
    public void TestDrive(CarFactory carFactory)
    {
        Car car = carFactory.CreateCar();
        car.Drive();
    }

    static void Main()
    {
        Client client = new Client();

        CarFactory fordFactory = new FordFactory();
        client.TestDrive(fordFactory);  

        CarFactory toyotaFactory = new ToyotaFactory();
        client.TestDrive(toyotaFactory); 
    }