namespace APBD3;

public class GasContainer : Container,IHazardNotifier
{
    public GasContainer(double Height, double Width, double Weight, double MaxPayload)
    {
        this.Height = Height;
        this.Width = Width;

        this.Netto = 0;
        this.ContainerWeight = Weight;
        this.MaxPayload = MaxPayload;
        SerialNumber = SerialNumber + "G-" + idSerial;
        idSerial++;
    }
    public override void Empty()
    {
        Netto = MaxPayload * 0.05;
    }

    public override void Load(double weight, string product)
    {
        if (this.Netto + weight > MaxPayload)
        {
            Console.WriteLine("GasContainer cannot be filled out of maximum payload");
        }
        else
        {
            this.Netto += weight;
            Console.WriteLine("Container " + this.SerialNumber + " loaded with " + weight + "L of " + product);
        }
        
    }
    
    public override void info()
    {
        Console.WriteLine($"SN: {SerialNumber} | HGT: {Height} | WID: {Width} " +
                          $"| NET:{Netto} | CONW:{ContainerWeight} | MAXW:{MaxPayload}");
    }

    public void Notify()
    {
        Console.WriteLine("DANGER: Gas Container has hazardous product in it!");
    }
}