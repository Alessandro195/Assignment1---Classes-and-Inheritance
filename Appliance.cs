using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Classes_and_Inheritance
{
    public abstract class Appliance
    {
        public string ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Wattage { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        protected Appliance(string itemNumber, string brand, int quantity, int wattage, string color, decimal price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        public abstract override string ToString();

        public static List<Appliance> LoadAppliancesFromFile(string filePath)
        {
            List<Appliance> appliances = new List<Appliance>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');

                if (parts.Length > 0)
                {
                    string itemType = parts[0];

                    Appliance appliance = itemType switch
                    {
                        "Dishwasher" => new Dishwasher(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], decimal.Parse(parts[6]), parts[7], parts[8]),
                        "Microwave" => new Microwave(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], decimal.Parse(parts[6]), double.Parse(parts[7]), parts[8]),
                        "Vacuum" => new Vacuum(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], decimal.Parse(parts[6]), parts[7], int.Parse(parts[8])),
                        "Refrigerator" => new Refrigerator(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], decimal.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9])),
                        _ => null
                    };

                    if (appliance != null)
                        appliances.Add(appliance);
                }
            }
            return appliances;
        }


        public static void SaveAppliancesToFile(string filePath, List<Appliance> appliances)
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var appliance in appliances)
            {
                writer.WriteLine(appliance);
            }
        }
    }
}
