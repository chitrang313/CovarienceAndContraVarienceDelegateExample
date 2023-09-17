using System.Reflection;

class Program {
    private delegate Car CarFactoryDel(int id, string name);    

    static void Main(string[] args) {
        CarFactoryDel carDel = CarFactory.ReturnICECar;

        Car iceCar = carDel(1, "Audi A8");

        Console.WriteLine($"{iceCar.GetType()}");
        Console.WriteLine($"{iceCar.GetCarDetails()}");
       
        carDel = CarFactory.ReturnEVCar;

        Car evCar = carDel(2,"Tesla S9");

        Console.WriteLine();
        Console.WriteLine(evCar.GetType());
        Console.WriteLine(evCar.GetCarDetails());
    }
}

public static class CarFactory {
    public static ICECar ReturnICECar(int id,string name) {
        return new ICECar { Id = id,Name = name };
    }

    public static EVCar ReturnEVCar(int id,string name) {
        return new EVCar { Id = id,Name = name };
    }
}


public abstract class Car {
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual string GetCarDetails() {
        return $"{Id}: {Name}";
    }
}

public class ICECar:Car {
    public override string GetCarDetails() {
        return $"{base.GetCarDetails()} - Internal Combution Engin Car";
    }
}

public class EVCar:Car {
    public override string GetCarDetails() {
        return $"{base.GetCarDetails()} - Electric Vehical Car";
    }
}