using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Classes_and_Inheritance
{
    class Program
    {
        static List<Appliance> appliances = new List<Appliance>();

        static void Main()
        {
            LoadAppliances();
            while (true)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit");
                Console.Write("Enter option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1": CheckoutAppliance(); break;
                    case "2": FindByBrand(); break;
                    case "3": DisplayByType(); break;
                    case "4": DisplayRandom(); break;
                    case "5": SaveAppliances(); return;
                    default: Console.WriteLine("Invalid option. Try again."); break;
                }
            }
        }

        static void LoadAppliances()
        {
            string[] lines = File.ReadAllLines("appliances.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                string itemNumber = parts[0];
                char type = itemNumber[0];

                if (type == '1') appliances.Add(new Refrigerator(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4], decimal.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
                else if (type == '2') appliances.Add(new Vacuum(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4], decimal.Parse(parts[5]), parts[6], int.Parse(parts[7])));
                else if (type == '3') appliances.Add(new Microwave(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4], decimal.Parse(parts[5]), double.Parse(parts[6]), parts[7]));
                else if (type == '4' || type == '5') appliances.Add(new Dishwasher(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), parts[4], decimal.Parse(parts[5]), parts[6], parts[7]));
            }
        }

        static void CheckoutAppliance()
        {
            Console.Write("Enter the item number of an appliance: ");
            string itemNumber = Console.ReadLine();

            Appliance appliance = appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);

            if (appliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else if (appliance.Quantity == 0)
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
            else
            {
                appliance.Quantity--;
                Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
            }

            Console.WriteLine(); 
        }

        static void FindByBrand()
        {
            Console.Write("Enter brand to search for: ");
            string brand = Console.ReadLine().Trim(); 

            var matchingAppliances = appliances
                .Where(a => a.Brand.Trim().Equals(brand, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingAppliances.Count == 0)
            {
                Console.WriteLine("No appliances found for the specified brand.");
            }
            else
            {
                Console.WriteLine("Matching Appliances:");
                foreach (var appliance in matchingAppliances)
                {
                    Console.WriteLine(appliance);
                }
            }

            Console.WriteLine();
        }


        static void DisplayByType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write("Enter type of appliance: ");
            string typeOption = Console.ReadLine();

            List<Appliance> filteredAppliances = new List<Appliance>();

            switch (typeOption)
            {
                case "1":
                    Console.Write("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");
                    if (int.TryParse(Console.ReadLine(), out int doors))
                    {
                        filteredAppliances = appliances
                            .OfType<Refrigerator>()
                            .Where(r => r.NumberOfDoors == doors)
                            .Cast<Appliance>()
                            .ToList();
                    }
                    Console.WriteLine("Matching refrigerators:");
                    break;

                case "2": 
                    Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high): ");
                    if (int.TryParse(Console.ReadLine(), out int voltage))
                    {
                        filteredAppliances = appliances
                            .OfType<Vacuum>()
                            .Where(v => v.BatteryVoltage == voltage)
                            .Cast<Appliance>()
                            .ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 18 or 24.");
                    }
                    Console.WriteLine("Matching vacuums:");
                    break;


                case "3": 
                    Console.Write("Room where the microwave will be installed: K (kitchen) or W (work site): ");
                    string roomType = Console.ReadLine();
                    filteredAppliances = appliances
                        .OfType<Microwave>()
                        .Where(m => m.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase))
                        .Cast<Appliance>() 
                        .ToList();
                    Console.WriteLine("Matching microwaves:");
                    break;

                case "4": 
                    Console.Write("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate): ");
                    string soundRating = Console.ReadLine();
                    filteredAppliances = appliances
                        .OfType<Dishwasher>()
                        .Where(d => d.SoundRating.Equals(soundRating, StringComparison.OrdinalIgnoreCase))
                        .Cast<Appliance>()
                        .ToList();
                    Console.WriteLine("Matching dishwashers:");
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            if (filteredAppliances.Count == 0)
            {
                Console.WriteLine("No appliances found for the selected criteria.");
            }
            else
            {
                foreach (var appliance in filteredAppliances)
                {
                    Console.WriteLine(appliance);
                }
            }

            Console.WriteLine();
        }



        static void DisplayRandom()
        {
            Console.Write("Enter number of appliances: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Random random = new Random();
            var randomAppliances = appliances.OrderBy(_ => random.Next()).Take(count).ToList();

            if (randomAppliances.Count == 0)
            {
                Console.WriteLine("No appliances available.");
            }
            else
            {
                Console.WriteLine("Random appliances:");
                foreach (var appliance in randomAppliances)
                {
                    Console.WriteLine(appliance);
                }
            }

            Console.WriteLine();
        }

        static void SaveAppliances() {}
    }
}
