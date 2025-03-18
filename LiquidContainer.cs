namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier             //LIQUIDDDDD
{
    public bool Hazardous { get; set; }

    public LiquidContainer(double Height, double Width, double Weight, double MaxPayload) : base()
    {
        
        this.Height = Height;
        this.Width = Width;

        this.Netto = 0;
        this.ContainerWeight = Weight;
        
        this.MaxPayload = MaxPayload;
        SerialNumber = SerialNumber + "L-" + idSerial;
        idSerial++;
    }
    
    public override void Empty()
    {
        Hazardous = false;
        Netto = 0;
    }

    public override void Load(double weight, string product)
    {
        if (Netto != 0)
        {
            Console.WriteLine("Cannot load until empty.");
        }
        else
        {
            if (product == "Fuel")
            {
                Hazardous = true;
                if (this.Netto + weight <= this.MaxPayload * 0.5)
                {
                    this.Netto = this.Netto + weight;
                    Console.WriteLine("Container " + this.SerialNumber + " loaded with " +weight +"L of " + product);
                }
                else
                {
                    Console.WriteLine("WARNING: Container weight is too small (hazardous)");
                }
            }
            else
            {
                Hazardous = false;
                if (this.Netto + weight <= this.MaxPayload * 0.9)
                {
                    this.Netto = this.Netto + weight;
                    Console.WriteLine("Container " + this.SerialNumber + " loaded with " +weight +"L of " + product);
                }
                else
                {
                    Console.WriteLine("WARNING: Container weight is too small (normal)");
                }
            } 
        }
       
        
    }

    public override void info()
    {
        Console.WriteLine($"SN: {SerialNumber} | HGT: {Height} | WID: {Width} " +
                          $"| NET:{Netto} | CONW:{ContainerWeight} | MAXW:{MaxPayload} | HAZ:{Hazardous}");
    }

    public void Notify()
    {
        Console.WriteLine("DANGER: Liquid Container has hazardous product in it!");
    }
}