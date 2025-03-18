namespace APBD3;

public abstract class Container
{
    public static int idSerial = 0;
    
    public double Height { get; set; } //useless
    public double Width { get; set; } //useless

    public double Netto { get; set; }
    public double ContainerWeight { get; set; }
    public string SerialNumber { get; set; } = "KON-";
    public double MaxPayload { get; set; }
    

    public abstract void Empty();

    public abstract void Load(double weight, string product);

    public abstract void info();
}