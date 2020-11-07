using System;

namespace HotelReservationSystem__WorkshopDay19
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel call = new Hotel();
            Console.WriteLine("---------------------------------\nWelcome to the Hotel Reservation System\n---------------------------------");
            Console.WriteLine("enter 1 to view the hotel details\nenter 2 to calculate the hotel rent");
            int input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    call.HotelDetails();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Please enter the of your check in in the format Day/Month/Year: ");
                    DateTime checkin = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the of your check out: ");
                    DateTime checkOut = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Minimum rent for the given dates is: ");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
