/* Author: Eric McLaughlin
 * Last Date Modified: April 8, 2020
 * 
 * Purpose: Allow the user to enter a number of invoices into the program and display their current invoice, save their invoice to a list and save that list of invoices to a file.
 *          Also to read a list of invoices from a file. And to display the list of invoices in a table.
 * 
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace BikeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //initalize objects and variables
            List<Invoice> invoices = new List<Invoice>();
            Invoice currentInvoice = new Invoice();
            int menuChoice;


            //display header
            Console.WriteLine("The Right Bike Shop");
            Console.WriteLine("*******************");


            //loop through until user selects option to exit program
            do
            {
                //display menu options
                menuChoice = getMenuChoice();

                if (menuChoice == 1)
                {
                    //prompt user for their name and store it
                    EnterName(currentInvoice);
                    Console.WriteLine();
                }
                else if (menuChoice == 2)
                {
                    //display a list of available brands, prompt the user for the choice and store it
                    ChooseBrand(currentInvoice);
                    Console.WriteLine();
                }
                else if (menuChoice == 3)
                {
                    //display the availbe tire sizes, prompt the user for their choice and store it
                    ChooseTireSize(currentInvoice);
                    Console.WriteLine();
                }
                else if (menuChoice == 4)
                {
                    //display a list of available metals, prompt the user for their choice and store it
                    ChooseCompositeValue(currentInvoice);
                    Console.WriteLine();
                }
                else if (menuChoice == 5)
                {
                    //prompt the user to enter a donation amount and store it
                    Donation(currentInvoice);
                    Console.WriteLine();
                }
                else if (menuChoice == 6)
                {
                    //display the packing slip for the current invoice
                    Console.WriteLine();
                    currentInvoice.Display();
                    Console.WriteLine();
                }
                else if (menuChoice == 7)
                {
                    //save the current invoice to a list a create a new invoice
                    if (!(currentInvoice.Name == "n/a" || currentInvoice.Brand == '-' || currentInvoice.TireSize == 0 || currentInvoice.Metal == 0))
                    {
                        invoices.Add(currentInvoice);
                        currentInvoice = new Invoice();
                    }
                    else
                    {
                        Console.Write("Invoice could not be added, one or more fields has not been set.");
                    }
                    Console.WriteLine();
                }
                else if (menuChoice == 8)
                {
                    //prompt the user for a file path and read in a list of invoices from it
                    invoices = ReadFromFile();
                    Console.WriteLine();
                }
                else if (menuChoice == 9)
                {
                    //prompt the user for a file path and write the list of invoices to it
                    WriteToFile(invoices);
                    Console.WriteLine();
                }
                else if (menuChoice == 10)
                {
                    //display the list of invoices in a table
                    DisplayAllInvoices(invoices);
                    Console.WriteLine();
                }
                //exit program is 11 is chosen
            } while (menuChoice != 11);
        }

        static public int getMenuChoice()
        {
            int menuChoice;

            //display menu options
            Console.WriteLine("Please select one of the following menu options:");
            Console.WriteLine("1. Enter Name");
            Console.WriteLine("2. Select Brand");
            Console.WriteLine("3. Select Tire Size");
            Console.WriteLine("4. Select Metal");
            Console.WriteLine("5. Add Donation");
            Console.WriteLine("6. Display Invoice");
            Console.WriteLine("7. Save Invoice");
            Console.WriteLine("8. Read Invoices from File");
            Console.WriteLine("9. Write Invoics to File");
            Console.WriteLine("10. Display All Invoices");
            Console.WriteLine("11. Exit");

            //get int between 1 and 8
            menuChoice = getSafeInt("Enter your selection (1-11): ", 1, 11);

            return menuChoice;
        }

        //get a valid int from the user
        static public int getSafeInt(string prompt)
        {
            int safeInt = 0;
            bool validData = false;

            //loop through until valid data is entered
            do
            {
                //prompt user user given prompt
                Console.Write(prompt);
                try
                {
                    safeInt = int.Parse(Console.ReadLine());
                    validData = true;
                }
                //handle any exception
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            } while (!validData);

            return safeInt;
        }

        //get a valid int between min and max values from the user
        static public int getSafeInt(string prompt, int min, int max)
        {
            int safeInt;
            bool validData = false;

            //loop through until valid data is entered
            do
            {
                //get valid int from getSafeInt
                safeInt = getSafeInt(prompt);

                //check if it is in range if not tell user if it is exit loop
                if (safeInt >= min && safeInt <= max)
                {
                    validData = true;
                }
                else
                {
                    Console.WriteLine("Input out of range, try again");
                }
            } while (!validData);

            return safeInt;
        }


        //get a valid double from the user
        static public double getSafeDouble(string prompt)
        {
            double safeDouble = 0;
            bool validData = false;

            //loop through until valid data is entered
            do
            {
                //prompt user using given prompt
                Console.Write(prompt);
                try
                {
                    safeDouble = double.Parse(Console.ReadLine());
                    validData = true;
                }
                //handle any exception
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            } while (!validData);

            return safeDouble;
        }

        //get safe double within min and max value from user
        static public double getSafeDouble(string prompt, double min, double max)
        {
            double safeDouble;
            bool validData = false;

            //loop through until valid data is entered
            do
            {
                safeDouble = getSafeDouble(prompt);

                //check if user input is within range if it is exit loop if not tell user and continue loop
                if (safeDouble >= min && safeDouble <= max)
                {
                    validData = true;
                }
                else
                {
                    Console.WriteLine("Input out of range, try again");
                }
            } while (!validData);

            return safeDouble;
        }

        //promp the user to enter a name and store it in a given Invoice object
        static void EnterName(Invoice invoice)
        {
            bool validData = false;
            //loop through until a valid name is entered
            do
            {
                //prompt user for a name
                Console.Write("Enter a name: ");
                try
                {
                    //store the name
                    invoice.Name = Console.ReadLine();
                    validData = true;
                }
                catch (Exception ex)
                {
                    //if an exception is thrown display the message
                    Console.WriteLine($"Error: {ex.Message} Try again");
                    Console.WriteLine();
                }
            } while (!validData);
        }

        //display available brands prompt users for their selection and return their choice in a given Invoice object
        static void ChooseBrand(Invoice invoice)
        {
            bool validData = false;

            //display available brands
            Console.WriteLine("Available brands");
            Console.WriteLine(" a) Trek");
            Console.WriteLine(" b) Giant");
            Console.WriteLine(" c) Specialized");
            Console.WriteLine(" d) Raleigh");

            //loop through until valid data is entered
            do
            {
                Console.Write("Enter your selection (a, b, c, d): ");
                try
                {
                    invoice.Brand = Console.ReadLine()[0];
                    validData = true;
                }
                //if an exception is thrown display the message
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                    Console.WriteLine();
                }
            } while (!validData);
        }

        //display available tire sizes and return their selection
        static void ChooseTireSize(Invoice invoice)
        {
            //prompt user for their prefered tire size and store it
            invoice.TireSize = getSafeInt("Select a tire size (20-26) @ $17.50 per inch: ", 20, 26);
        }

        //display available metals and prompt users for their selection and return the premium
        static void ChooseCompositeValue(Invoice invoice)
        {
            //display available metal alloys
            Console.WriteLine("Available metal alloys");
            Console.WriteLine(" 1) Steel ($0)");
            Console.WriteLine(" 2) Aluminum ($175)");
            Console.WriteLine(" 3) Titanium ($425)");
            Console.WriteLine(" 4) Carbon Fibre ($615)");

            //prompt user for selection and store it
            invoice.Metal = getSafeInt("Enter your selection (1-4): ", 1, 4);


        }

        //prompt users for a donation amount and set the Invoice object variable to that amount if it is greater than or equal to 0
        static void Donation(Invoice invoice)
        {
            bool validData = false;

            do
            {
                try
                {
                    //ask for the amount and store it
                    invoice.Donation = getSafeDouble("Enter amount: ");
                    validData = true;
                }
                //if an exception is thrown display the message
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }

            } while (!validData);
        }

        //method will read client data from a file selected by the user into a list of Invoice objects
        static List<Invoice> ReadFromFile()
        {
            //initialize objects and variables
            List<Invoice> invoices = new List<Invoice>();
            Invoice current;
            StreamReader file;
            string[] lineArray;
            string filePath;
            string line;
            int lineNum = 0;

            //prompt user for file path
            Console.Write("Enter the file to read from: ");
            filePath = Console.ReadLine();

            try
            {
                //open file
                file = new StreamReader(filePath);

                //go through file line by line
                while ((line = file.ReadLine()) != null)
                {
                    //keep track of current line number
                    lineNum++;
                    //split each line into an array of strings and create a new Invoice object with the values read from the file
                    current = new Invoice();
                    lineArray = line.Split(", ");

                    //store the values into the current Invoice object
                    current.Name = lineArray[0];
                    current.BrandName = lineArray[1];
                    current.TireSize = int.Parse(lineArray[2]);
                    current.MetalPremium = double.Parse(lineArray[3]);
                    current.Donation = double.Parse(lineArray[4]);

                    //add new Invoice object to the list
                    invoices.Add(current);
                }

                //close the file
                file.Close();
            }
            //if the file cannot be opened or read from display the message
            catch (Exception ex)
            {
                Console.Write($"Error reading from file {filePath} with exception: {ex.Message}");
                //if the file opened and the error was from the values being read display the line the error was found on
                if (lineNum > 0)
                {
                    Console.WriteLine($" on line {lineNum}");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            //return the list of Invoices
            return invoices;
        }

        //this method will write the list of invoices to a file
        static void WriteToFile(List<Invoice> invoices)
        {
            StreamWriter file;
            String filePath;

            //get the path where the file will be stored
            Console.Write("Enter the file to write to: ");
            filePath = Console.ReadLine();

            try
            {
                //open the file
                file = new StreamWriter(filePath);

                //for every Invoice object in the list
                foreach (Invoice invoice in invoices)
                {
                    //write each entry of the Invoice objects to the file in the format of "{Name}, {Brand}, {TireSize}, {MetalPremium}, {Donation}"
                    file.WriteLine($"{invoice.Name}, {invoice.BrandName}, {invoice.TireSize}, {invoice.MetalPremium}, {invoice.Donation}");
                }

                //close the file
                file.Close();
            }
            //if an exception is thrown display the message
            catch (Exception ex)
            {
                Console.Write($"Error writing to file {filePath} with exception {ex.Message}");
            }
        }

        //this method will display the list of Invoice objects in a table if it is not empty
        static void DisplayAllInvoices(List<Invoice> invoices)
        {
            if (invoices.Count > 0)
            {
                Console.WriteLine($"{"Client",-20}{"Brand",-15}{"Tires",-10}{"Metal",10}{"Donation",12}");
                Console.WriteLine("-------------------------------------------------------------------");
                foreach (Invoice invoice in invoices)
                {
                    Console.WriteLine($"{invoice.Name,-20}{invoice.BrandName,-15}{invoice.TireSize,-10}{invoice.MetalPremium,10:0.00}{invoice.Donation,12:0.00}");
                }
            }
            else
            {
                Console.WriteLine("There are no saved invoices to be listed.");
            }
        }
    }


    
}