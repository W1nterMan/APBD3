namespace APBD3;

public class RefrigeratedContainer : Container
{
    Dictionary<string, double> products = new Dictionary<string, double>()
    {
        {"Bananas", 13.3 },
        {"Chocolate", 18 },
        {"Fish", 2},
        {"Meat",-15},
        {"IceCream", -18},
        {"FrozenPizza", -30},
        {"Cheese" , 7.2},
        {"Sausages" , 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double Height, double Width, double Weight, double MaxPayload
        ,string productType)
    {
        this.Height = Height;
        this.Width = Width;

        this.Netto = 0;
        this.ContainerWeight = Weight;
        
        this.MaxPayload = MaxPayload;
        ProductType = productType;
        if (products.ContainsKey(productType))
        {
            Temperature = products[productType];
        }
        else
        {
            Console.WriteLine("There is no product of type " + productType);
        }
        
        SerialNumber = SerialNumber + "C-" + idSerial;
        idSerial++;
    }
    public override void Empty()
    {
        ProductType = string.Empty;
        Netto = 0;
    }
    
    public override void info()
    {
        Console.WriteLine($"SN: {SerialNumber} | HGT: {Height} | WID: {Width} " +
                          $"| NET:{Netto} | CONW:{ContainerWeight} | MAXW:{MaxPayload} | PROD:{ProductType} | TEMP:{Temperature}");
    }

    public override void Load(double weight, string product)
    {
        if (product == ProductType && Temperature >= products[product])
        {
            if (Netto + weight <= MaxPayload)
            {
                Netto += weight; 
                Console.WriteLine("Container " + this.SerialNumber + " loaded with " + weight +"KG of " + product);
            }
            else
            {
                Console.WriteLine("Cannot overfill container");
            }
        }
        else
        {
            Console.WriteLine("Not the same product or temperature is too low in it");
        }
    }
}