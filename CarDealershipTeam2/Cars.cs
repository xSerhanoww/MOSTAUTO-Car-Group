using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipTeam2
{
    internal class Cars
    {
        public int ID;
        public string Brand;
        public string Model;
        public int YearOfManufacture;
        public int HorsePower;
        public string FuelType;
        public string GearBox;
        public int Price;
        public string Color;
        public bool isNew;
        public int Mileage;
        public bool Availability;
        public string NewOwner;



        public string ToString()
        {
            return ($"ID: {ID},Brand: {Brand},Model: {Model},YearOfManufacture: {YearOfManufacture}," +
            $"HorsePower(HP): {HorsePower}hp,Fuel type: {FuelType},Gearbox: {GearBox},Price: {Price}BGN,Color: {Color}," + $"isNew: {isNew}," +
            $"Mileage: {Mileage}km,Availability: {Availability},NewOwner: {NewOwner}");
        }
    }
}
