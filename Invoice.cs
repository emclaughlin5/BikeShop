using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    class Invoice
    {
        private const int BasePrice = 500;
        private string name;
        private string brandName;
        private char brand;
        private int tireSize;
        private int metal;
        private double metalPremium;
        private double donation;

        public Invoice()
        {
            name = "n/a";
            brand = '-';
            tireSize = 0;
            metal = 0;
            donation = 0;
        }

        //getter and setter of the name property
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //check that the given string does not contain symbols, numbers or punctuation and is at least 2 characters long
                if (value.Length >= 2)
                {
                    foreach (char index in value)
                    {
                        if (!Char.IsLetter(index) && index != ' ')
                        {
                            throw new Exception("Names cannot contain numbers, symbols or punctuation.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Name must be 2 or more characters.");
                }
                name = value;
            }
        }

        //getter and setter of the brand property, the brandName property is also set accordingly
        public char Brand
        {
            get
            {
                return brand;
            }
            set
            {
                //if entered character is 'a', 'b', 'c' or 'd' set brand and brandName according to given value, if not throw exception to caller
                switch (value)
                {
                    case 'a':
                        brand = value;
                        brandName = "Trek";
                        break;

                    case 'b':
                        brand = value;
                        brandName = "Giant";
                        break;

                    case 'c':
                        brand = value;
                        brandName = "Specialized";
                        break;

                    case 'd':
                        brand = value;
                        brandName = "Raleigh";
                        break;
                    default:
                        throw new Exception("Value out of range.");
                }
            }
        }

        //getter and setter of the brandName property, the brand property is also set accordingly
        public string BrandName
        {
            get
            {
                return brandName;
            }
            set
            {
                //if entered string is "Trek", "Giant", "Specialized" or "Raleigh" set brand and brandName according to given value, if not throw exception to caller
                switch (value)
                {
                    case "Trek":
                        brand = 'a';
                        brandName = value;
                        break;

                    case "Giant":
                        brand = 'b';
                        brandName = value;
                        break;

                    case "Specialized":
                        brand = 'c';
                        brandName = value;
                        break;

                    case "Raleigh":
                        brand = 'd';
                        brandName = value;
                        break;
                    default:
                        throw new Exception("String entered is not a recognized brand.");
                }
            }
        }

        //getter and setter of the tireSize property
        public int TireSize
        {
            get
            {
                return tireSize;
            }
            set
            {
                //check if the given value is between 20 and 26
                if (value >= 20 && value <= 26)
                {
                    tireSize = value;
                }
                else
                {
                    throw new Exception("Value out of range.");
                }
            }
        }

        //getter and setter of the metal property, metalPremium also gets accordingly
        public int Metal
        {
            get
            {
                return metal;
            }
            set
            {
                //check if the given value is between 1 and 4 if it is set metal and metalPremium
                switch (value)
                {
                    case 1:
                        metal = value;
                        metalPremium = 0;
                        break;
                    case 2:
                        metal = value;
                        metalPremium = 175;
                        break;
                    case 3:
                        metal = value;
                        metalPremium = 425;
                        break;
                    case 4:
                        metal = value;
                        metalPremium = 615;
                        break;
                    default:
                        throw new Exception("Value out of range.");
                }
            }
        }

        //getter and setter of the metalPremium propery, also sets metal accordingly
        public double MetalPremium
        {
            get
            {
                return metalPremium;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        metal = 1;
                        metalPremium = 0;
                        break;
                    case 175:
                        metal = 2;
                        metalPremium = 175;
                        break;
                    case 425:
                        metal = 3;
                        metalPremium = 425;
                        break;
                    case 615:
                        metal = 4;
                        metalPremium = 615;
                        break;
                    default:
                        throw new Exception("Value out of range.");
                }
            }
        }


        //getter and setter of the donation property
        public double Donation
        {
            get
            {
                return donation;
            }
            set
            {
                //if donation is below 0 throw exception to caller
                //allow 0 as an amount incase the menu option was accidentially selected as the donation is optional
                if (value >= 0)
                {
                    donation = value;
                }
                else
                {
                    throw new Exception("Value out of range.");
                }
            }
        }

        //this method will display the packing slip of the invoice
        public void Display()
        {
            //initialize variables
            double subtotal, gst, total, tireSizePremium;

            //calculate tire size premium and metal premiums
            tireSizePremium = tireSize * 17.5;


            //display receipt header and customer name
            Console.WriteLine("Invoice and Packing Slip");
            Console.WriteLine($"Customer: {name}");

            //calcualte subtotal, gst and total
            subtotal = BasePrice + tireSizePremium + metalPremium;
            gst = subtotal * 0.05;
            total = subtotal + gst + donation;
            subtotal = Math.Round(subtotal, 2);
            gst = Math.Round(gst, 2);
            total = Math.Round(total, 2);


            //display their receipt with proper formatting
            Console.WriteLine($"{"Brand",-24} {brandName,15}");
            Console.WriteLine($"{"Base Price:",-24} {BasePrice,15:F2}");
            Console.WriteLine($"{"Tire Size Premium:",-24} {tireSizePremium,15:F2}");
            Console.WriteLine($"{"Metal Selection Premium:",-24} {metalPremium,15:F2}");
            Console.WriteLine($"{"-------",40}");
            Console.WriteLine($"{"Subtotal:",-24} {subtotal,15:F2}");
            Console.WriteLine($"{"GST:",-24} {gst,15:F2}");
            Console.WriteLine($"{"=======",40}");

            //display donation amount only if they made one
            if (donation > 0)
            {
                Console.WriteLine($"{"Donation to Green Earth:",-24} {donation,15:F2}");
            }
            //display their total
            Console.WriteLine($"{"Total:",-24} {total,15:F2}");
        }
    }
}
