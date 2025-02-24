using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment___Classes_and_Inheritance
{
    public class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public int BatteryVoltage { get; set; }

        public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string grade, int batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {BatteryVoltage}\n";
        }

    }
}
