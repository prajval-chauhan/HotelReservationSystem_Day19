using Microsoft.VisualBasic;
using System;
using System.Text.RegularExpressions;
using System.Transactions;

namespace HotelReservationSystem__WorkshopDay19
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel call = new Hotel();
            string customerType;
            Console.WriteLine("---------------------------------\nWelcome to the Hotel Reservation System\n---------------------------------");
            Console.WriteLine("enter 1 to view the hotel details\nenter 2 to find the best cheapest option" +
                "\nenter 3 to find the best rated hotel");
            int input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    call.HotelDetails();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("enter the date of your CHECK IN (DD/MM/YYYY): ");
                    DateTime checkin = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("enter the date of your CHECK OUT (DD/MM/YYYY): ");
                    DateTime checkOut = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the customer type i.e. regular/reward customer");
                    customerType = Console.ReadLine().ToLower();
                    call.CheapestAndBestRated(checkin,checkOut,customerType);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("enter the date of your CHECK IN (DD/MM/YYYY): ");
                    DateTime checkIn = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("enter the date of your CHECK OUT (DD/MM/YYYY): ");
                    DateTime checkout = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the customer type i.e. regular/reward customer");
                    customerType = Console.ReadLine().ToLower();
                    call.BestRatedRentFinder(checkIn, checkout, customerType);
                    Console.ReadKey();
                    break;
            }
        }
    }
}
