using APBD3;

//1.Create a container of a given type
LiquidContainer liquidContainer = new LiquidContainer(1,2,3,60);
LiquidContainer liquidContainer2 = new LiquidContainer(2, 9, 1, 88);
GasContainer gasContainer = new GasContainer(1,3,4,100);
RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(10,22,10,200,"Bananas");

//2.Load cargo
liquidContainer.Load(14,"Fuel");

liquidContainer2.Load(19,"Milk");

gasContainer.Load(20,"Gas");

refrigeratedContainer.Load(100,"Bananas");

//ship creation
Ship Hood = new Ship("Hood",20.2,12,200.2);
Ship Bismark = new Ship("Bismark",30, 22, 600); 

//3.Load a container onto a ship
Hood.load(liquidContainer);

//4.Load a list of containers onto ship
List<Container> supply = new List<Container>() { gasContainer, refrigeratedContainer };
Bismark.load(supply);

//5.Remove container from ship

Hood.unload(liquidContainer.SerialNumber);

//6.Unload a container

gasContainer.Empty();

//7.Replace a container on the ship with a given number with another container

Hood.change(liquidContainer,liquidContainer2);

//8.The possibility of transferring  a container between to ships

Ship.swap(Hood,Bismark,liquidContainer2);

//9.info container
gasContainer.info();
liquidContainer.info();
liquidContainer2.info();
refrigeratedContainer.info();

//10.info ship and cargo

Hood.info();
Bismark.info();

Console.WriteLine("Enter anything to clear test.");
Console.ReadLine();
Console.Clear();


bool exit = false;
string? Answer = "-1";
List<Ship> ships = new List<Ship>();
List<Container> containers = new List<Container>();


while (!exit)
{
    Console.WriteLine("System: Possible actions:" +
                      "\n\t 1. Add a container ship" +
                      "\n\t 2. Add a container**" +                     //only gas, cause same as below.
                      "\n\t ~~3. Remove a container ship~~" +
                      "\n\t ~~4. Remove container~~" +                  //too lazy to implement, not hard - tidious.
                      "\n\t ~~5. Place a container on a ship~~" +
                      "\n\t 9. Exit");
    Answer = Console.ReadLine();
    if (Answer == null || Answer == "-1")
    {
        Console.WriteLine("System: Input answer please.");
    } else
        switch (Answer)
        {
            case "1":
            {
                Console.WriteLine("Enter: [NAME SPEED MAXAMMOUNT MAXWEIGHT]");
                string? input = "";
                input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("System: Aborting operation, null");
                }
                else
                {
                    string[] param;
                    param = input.Split(' ');
                    if (param.Length != 4)
                    {
                        Console.WriteLine("System: Not enough parameters.");
                    }
                    else
                    {
                        ships.Add(new Ship(param[0],double.Parse(param[1]),int.Parse(param[2]),int.Parse(param[3])));
                        Console.WriteLine("System: Added ship +");
                        ships[ships.Count-1].info();
                    }
                    
                }
                break;
            }
            case "2":
            {
                Console.WriteLine("Enter: [Gas,Liq,Frg]");
                string? input = "";
                input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("System: Aborting operation, null");
                }

                if (input.Split().Length != 1)
                {
                    Console.WriteLine("System: Aborting, not 1 parameter.");
                }
                else
                {
                    switch (input)
                    {
                        case "Gas":
                        {
                            Console.WriteLine("Enter: [HEIGHT WIDTH WEIGHT MAXPAYLOAD]");
                            string? input1 = "";
                            input1 = Console.ReadLine();
                            if (input1 == null)
                            {
                                Console.WriteLine("System: Aborting operation, null");
                            }
                            if (input1 != null && input1.Split(' ').Length != 4)
                            {
                                Console.WriteLine("System: Aborting, not 4 parameters.");
                            }
                            else
                            {
                                var param = input1?.Split(' ');
                                containers.Add(new GasContainer(double.Parse(param[0]),double.Parse(param[1]),double.Parse(param[2]),double.Parse(param[3])));
                                Console.WriteLine("System: Added GasContainer");
                                containers[containers.Count-1].info();
                            }
                            

                            break;
                        }
                    }
                }

                break;
            }
            case "9":
            {
                Console.WriteLine("System: Exiting...");
                exit = true;
                break;
            }
        }
}
 