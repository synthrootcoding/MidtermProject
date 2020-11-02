﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml;

namespace MidtermProject
{
    class Menu
    {
        //public List<Item> Items { get; set } <== I need to know what the text file list class is called so I can link it in here

        public static void PrintStore()
        {
            List<string> itemsForSale = new List<string>();
            StreamReader reader = new StreamReader("../../../MenuItems.txt");
            string material = reader.ReadLine();
            while(material != null)
            {
                itemsForSale.Add(material);
                material = reader.ReadLine();
            }
            reader.Close();

            for (int i = 0; i < itemsForSale.Count; i++)
            {
                Console.WriteLine($"#{i+1}:  {itemsForSale[i]}");
            }
           
        }


        public static void DisplayLineTotal()
        {
            //item[i] * quantity
            //"You selected (item) x (quantity). That's (price) Would you like to checkout now or continue shopping?"
            //if user response == y
            //return to 
        }

        public static void SelectPayment(string paymentType, double amount) //<-- change this from void to payment once it's created 
                                                                            // in the () you can type the message "how do you want to pay today
                                                                            //and return that response to then divert to one of these choices
        {
            bool valid = true;
            while (valid == true)
            {
                //string paymentType = Console.ReadLine(); //<-- I think we should move this method to the program
                if (paymentType == "cash")
                {
                    double cash = double.Parse(GetUserInput("How much are you paying with in cash?: "));
                    Cash cash1 = new Cash(amount, cash);
                    cash1.GetChange(cash, amount);
                }
                //pull cash method which will prompt accordingly
                if (paymentType == "creditCard")
                {
                    string cardNumber = GetUserInput("Input your card number");
                    string expiration = GetUserInput("Input the expiration date [MM/YY]");
                    int securityCw = int.Parse(GetUserInput("Input the security number (CW)"));
                    Credit credit1 = new Credit(amount, cardNumber, expiration, securityCw);
                    credit1.PayWithCredit();
                }
                else if (paymentType == "check")
                {
                    int checkNumber = int.Parse(GetUserInput("Please input your check number"));
                    Check check1 = new Check(amount, checkNumber);
                    check1.PayWithCheck(amount, checkNumber);
                }
                else
                {
                    Console.WriteLine("Sorry. That is not an accepted method of payment. Please try again.");
                    valid = true;
                }
                //public static object GetDetail() //<== rename 'object' to Item 
                //{
                //    //get the input number that coordinates with the item number and show all the info on it
                //} 
            }
        }
        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string UserInput = Console.ReadLine();
            return UserInput;
        }

        //static string GetReceipt()
        //{
        //    Console.WriteLine("Thanks for shopping with us.  Here is your receipt: ");


        //}
    }
}
