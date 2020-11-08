using System;

namespace HotelReservationSystem__WorkshopDay19
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel call = new Hotel();
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
                    call.CheapestAndBestRated(checkin,checkOut,CustomerType.REGULAR);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("enter the date of your CHECK IN (DD/MM/YYYY): ");
                    DateTime checkIn = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("enter the date of your CHECK OUT (DD/MM/YYYY): ");
                    DateTime checkout = DateTime.Parse(Console.ReadLine());
                    call.BestRatedRentFinder(checkIn, checkout, CustomerType.REGULAR);
                    Console.ReadKey();
                    break;
            }
        }
    }
}
