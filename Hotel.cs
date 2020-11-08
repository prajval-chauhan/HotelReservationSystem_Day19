using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HotelReservationSystem__WorkshopDay19
{
    public class Hotel
    {
        /// <summary>
        /// The rate variable is declared which will assume different rate values for different hotels to calculate the rent 
        /// </summary>
        public int rate;
        /// <summary>
        /// This method generates the rent for all the hotels and then returns the cheapest option
        /// </summary>
        /// <param name="checkIn">The check in.</param>
        /// <param name="checkOut">The check out.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public void RentGenerator(DateTime checkIn, DateTime checkOut, CustomerType type)
        {
            int noOfDays = Convert.ToInt32((checkOut - checkIn).TotalDays);
            int lakewoodRent = HotelRentGenerator(HotelName.Lakewood, CustomerType.REGULAR, noOfDays);
            int bridgewoodRent = HotelRentGenerator(HotelName.Bridgewood, CustomerType.REGULAR, noOfDays);
            int ridgewoodRent = HotelRentGenerator(HotelName.Ridgewood, CustomerType.REGULAR, noOfDays);
            int minRent = Math.Min(lakewoodRent, Math.Min(bridgewoodRent, ridgewoodRent));
            if(minRent == lakewoodRent)
                Console.WriteLine("The cheapest hotel is 'Hotel Lakewood' with rent=$"+lakewoodRent);
            else if(minRent == bridgewoodRent)
                Console.WriteLine("The cheapest hotel is 'Hotel Bridgewood' with rent=$" + bridgewoodRent);
            else
                Console.WriteLine("The cheapest hotel is 'Hotel Ridgewood' with rent=$" + ridgewoodRent);
        }
        /// <summary>
        /// calculates and returns the rents for different hotels 
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="noOfDays">The no of days.</param>
        /// <returns></returns>
        /// <exception cref="HotelReservationException">
        /// throws exception Hotel doesn't exist for invalid hotel name 
        /// or
        /// throws exception Invalid Customer Type when wrong customer type is entered.
        /// </exception>
        public int HotelRentGenerator(HotelName name, CustomerType type, int noOfDays)
        {
            if (type.Equals(CustomerType.REGULAR))
            {
                if (name.Equals(HotelName.Lakewood))
                {
                    rate = 110;
                    return (rate * noOfDays);
                }
                if (name.Equals(HotelName.Bridgewood))
                {
                    rate = 160;
                    return (rate * noOfDays);
                }
                if (name.Equals(HotelName.Ridgewood))
                {
                    rate = 220;
                    return (rate * noOfDays);
                }
                else
                    throw new HotelReservationException(HotelReservationException.ExceptionType.NO_SUCH_HOTEL, "Hotel doesn't exist");
            }
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.NO_SUCH_CUSTOMER_TYPE, "Invalid Customer Type");
        }
        /// <summary>
        /// Displays the details of the hotels such as ratings and rents
        /// </summary>
        public void HotelDetails()
        {
            Console.WriteLine("***********************\nHotel Name: Lakewood\nRating: 3 star\nPrice: $110 per day\n***********************");
            Console.WriteLine("***********************\nHotel Name: Bridgewood\nRating: 4 star\nPrice: $160 per day\n***********************");
            Console.WriteLine("***********************\nHotel Name: Ridgewood\nRating: 5 star\nPrice: $220 per day\n***********************");
        }
    }
}
