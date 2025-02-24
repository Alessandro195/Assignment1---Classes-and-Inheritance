using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Classes_and_Inheritance
{
    public class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Refrigerator(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, int numberOfDoors, int height, int width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            NumberOfDoors = numberOfDoors;
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nNumber of Doors: {NumberOfDoors}\nHeight: {Height}\nWidth: {Width}\n";
        }
    }
}
