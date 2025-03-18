namespace APBD3;

public class Ship
{
    public List<Container> Containers { get; set; }
    public string Name { get; set; }
    public double Speed { get; set; }
    public int MaxAmount { get; set; }
    public double MaxWeight { get; set; }

    public Ship(string name,double speed, int maxAmount, double maxWeight)
    {
        this.Name = name;
        Speed = speed;
        this.MaxAmount = maxAmount;
        this.MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public double massofship()
    {
        double currentmass = 0;
        foreach (var container in Containers)
        {
            currentmass = currentmass + container.Netto + container.ContainerWeight;
        }

        return currentmass;
    }

    public void load(Container container)
    {
        if (Containers.Count < MaxAmount && massofship()+container.Netto+container.ContainerWeight <= MaxWeight)
        {
            Containers.Add(container);
        }
        else
        {
            Console.WriteLine("Ship is full, cancelling load of : " + container.SerialNumber);
        }
        Console.WriteLine("Loaded: " + container.SerialNumber + " into " + this.Name);
    }

    public void load(List<Container> listcontainer)
    {
        foreach (var container in listcontainer)
        {
            if (Containers.Count < MaxAmount && massofship()+container.Netto+container.ContainerWeight <= MaxWeight)
            {
                Containers.Add(container);
                Console.WriteLine("Loaded: " + container.SerialNumber + " into " + this.Name);
            }
            else
            {
                Console.WriteLine("Ship is full, cancelling load of : " + container.SerialNumber);
            }
        }
    }

    public void change(Container con1, Container con2)
    {
        if (con1 == con2)
        {
            Console.WriteLine("Same containers >:(");
            return;
        }
        if (massofship()+con2.Netto+con2.ContainerWeight <= MaxWeight)
        {
            //Containers.Remove(con1);
            this.unload(con1.SerialNumber);
            //Containers.Add(con2);
            this.load(con2);
            Console.WriteLine($"|| Changed {con1.SerialNumber} for {con2.SerialNumber} on {this.Name}");
        }
        else
        {
            Console.WriteLine("Cannot change containers.");
        }
        
    }

    public static void swap(Ship ship1, Ship ship2, Container container)
    {
        if (ship2.massofship()+container.Netto+container.ContainerWeight <= ship2.MaxWeight)
        {
            ship1.unload(container.SerialNumber);
            ship2.load(container);
            Console.WriteLine($"|| Mounted {container.SerialNumber} from {ship1.Name} to {ship2.Name}");
        }
        else
        {
            Console.WriteLine("Cannot swap container between 2 ships.");
        }
    }

    public void unload(string containerSerial)
    {
        Container temp = null;
        foreach (var container in Containers)
        {
            if (containerSerial == container.SerialNumber)
            {
                temp = container;
            }
        }

        if (temp != null) Containers.Remove(temp);
        Console.WriteLine("Unloaded: " + containerSerial + " from " + this.Name);
    }

    public void info()
    {
        Console.WriteLine($"<SHIP>   N:{Name} | MAXA:{MaxAmount} | MAXW:{MaxWeight}");
        foreach (var container in Containers){
            container.info();
        }
    }
}