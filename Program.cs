using System.Reflection;

class Program {
    private delegate Car CarFactoryDel(int id, string name);

    private delegate void LogIceCarDetail(ICECar iceCar);
    private delegate void LogEVCarDetail(EVCar evCar);

    static void Main(string[] args) {
        CarFactoryDel carDel = CarFactory.ReturnICECar;

        Car iceCar = carDel(1, "Audi A8");
        
        LogIceCarDetail iceCarLodDel = CarFactory.LogCarDetails;        
        iceCarLodDel(iceCar as ICECar);
        
        carDel = CarFactory.ReturnEVCar;

        Car evCar = carDel(2,"Tesla S9");

        LogEVCarDetail evCarLogDetail = CarFactory.LogCarDetails;
        evCarLogDetail(evCar as EVCar);

        Console.ReadLine();
    }
}

public static class CarFactory {
    public static ICECar ReturnICECar(int id,string name) {
        return new ICECar { Id = id,Name = name };
    }

    public static EVCar ReturnEVCar(int id,string name) {
        return new EVCar { Id = id,Name = name };
    }

    public static void LogCarDetails(Car car) {
        if(car is ICECar) {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICECarLogFile.txt");
            using (StreamWriter sw = new StreamWriter(filePath,true)) {
                sw.WriteLine(car.GetCarDetails());
            }
        }else if (car is EVCar) {
            Console.WriteLine(car.GetCarDetails());
        }else {
            throw new ArgumentException();
        }
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