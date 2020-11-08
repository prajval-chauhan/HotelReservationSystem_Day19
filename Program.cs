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
                    Console.WriteLine("Please enter the date of your CHECK OUT (DD/MM/YYYY): ");
                    DateTime checkin = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the date of your CHECK OUT (DD/MM/YYYY): ");
                    DateTime checkOut = DateTime.Parse(Console.ReadLine());
                    call.RentGenerator(checkin,checkOut,CustomerType.REGULAR);
                    Console.ReadKey();
                    break;
            }
        }
    }
}
