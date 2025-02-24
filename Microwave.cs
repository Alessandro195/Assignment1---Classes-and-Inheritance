using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Classes_and_Inheritance
{
    public class Microwave : Appliance
    {
        public double Capacity { get; set; }
        public string RoomType { get; set; }

        public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, double capacity, string roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nCapacity: {Capacity}\nRoom Type: {RoomType}\n";
        }
    }
}
