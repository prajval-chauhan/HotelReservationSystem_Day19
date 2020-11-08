using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HotelReservationSystem__WorkshopDay19
{
    public class Hotel
    {
        /// <summary>
        /// The rating of different hotels. Here rating = n means that the hotel is n starred.
        /// </summary>
        public static int RATING_LAKEWOOD = 3;
        public static int RATING_BRIDGEWOOD = 4;
        public static int RATING_RIDGEWOOD = 5;

        /// <summary>
        /// The regularRate and weekendRate variable is declared which will assume different rate values 
        /// for different hotels to calculate the rent 
        /// </summary>
        public int regularRate;
        public int weekendRate;
        public int noOfRegularDays;
        public int noOfWeekendDays;

        /// <summary>
        /// This method generates the rent for all the hotels and then returns the cheapest option
        /// </summary>
        /// <param name="checkIn">The check in.</param>
        /// <param name="checkOut">The check out.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public void CheapestAndBestRated(DateTime checkIn, DateTime checkOut, CustomerType type)
        {
            noOfWeekendDays = WeekendCount(checkIn, checkOut);
            noOfRegularDays = WeekdaysCount(checkIn, checkOut);
            int lakewoodRent = HotelRentGenerator(HotelName.Lakewood, CustomerType.REGULAR, noOfRegularDays, noOfWeekendDays);
            int bridgewoodRent = HotelRentGenerator(HotelName.Bridgewood, CustomerType.REGULAR, noOfRegularDays, noOfWeekendDays);
            int ridgewoodRent = HotelRentGenerator(HotelName.Ridgewood, CustomerType.REGULAR, noOfRegularDays, noOfWeekendDays);
            if ((lakewoodRent == bridgewoodRent && lakewoodRent <= ridgewoodRent) || (lakewoodRent == ridgewoodRent && lakewoodRent <= bridgewoodRent) || (bridgewoodRent == ridgewoodRent && bridgewoodRent <= lakewoodRent))
            {
                if (bridgewoodRent == ridgewoodRent)
                    Console.WriteLine("The cheapest hotel and best rated is 'Hotel Ridgewood' with rent= $" + ridgewoodRent);
                else if (lakewoodRent == ridgewoodRent)
                    Console.WriteLine("The cheapest hotel and best rated is 'Hotel Ridgewood' with rent= $" + ridgewoodRent);
                else if (lakewoodRent == bridgewoodRent)
                    Console.WriteLine("The cheapest and best rated hotel is 'Hotel Bridgewood' with rent= $" + bridgewoodRent);
                return;
            }
            int minRent = Math.Min(lakewoodRent, Math.Min(bridgewoodRent, ridgewoodRent));
            if(minRent == lakewoodRent)
                Console.WriteLine("The cheapest hotel is 'Hotel Lakewood' with rent = $"+lakewoodRent);
            if(minRent == bridgewoodRent)
                Console.WriteLine("The cheapest hotel is 'Hotel Bridgewood' with rent = $" + bridgewoodRent);
            if (minRent == ridgewoodRent)
                Console.WriteLine("The cheapest hotel is 'Hotel Ridgewood' with rent = $" + ridgewoodRent);
        }
        /// <summary>
        /// UC7: This method returns the rent for the best rated hotel
        /// </summary>
        /// <param name="checkIn">The check in.</param>
        /// <param name="checkOut">The check out.</param>
        /// <param name="type">The type.</param>
        public void BestRatedRentFinder(DateTime checkIn, DateTime checkOut, CustomerType type)
        {
            noOfWeekendDays = WeekendCount(checkIn, checkOut);
            noOfRegularDays = WeekdaysCount(checkIn, checkOut);
            int ridgewoodRent = HotelRentGenerator(HotelName.Ridgewood, CustomerType.REGULAR, noOfRegularDays, noOfWeekendDays);
            Console.WriteLine("The best rated is 'Hotel Ridgewood', rating: "+RATING_RIDGEWOOD+", rent= $" + ridgewoodRent);
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
        public int HotelRentGenerator(HotelName name, CustomerType type, int regularDays, int weekendDays)
        {
            if (type.Equals(CustomerType.REGULAR))
            {
                if (name.Equals(HotelName.Lakewood))
                {
                    regularRate = 110;
                    weekendRate = 90;
                    return (regularDays * regularRate + weekendDays * weekendRate);
                }
                if (name.Equals(HotelName.Bridgewood))
                {
                    regularRate = 150;
                    weekendRate = 50;
                    return (regularDays * regularRate + weekendDays * weekendRate);
                }
                if (name.Equals(HotelName.Ridgewood))
                {
                    regularRate = 220;
                    weekendRate = 150;
                    return (regularDays * regularRate + weekendDays * weekendRate);
                }
                else
                    throw new HotelReservationException(HotelReservationException.ExceptionType.NO_SUCH_HOTEL, "Hotel doesn't exist");
            }
            if (type.Equals(CustomerType.REWARD))
            {
                if (name.Equals(HotelName.Lakewood))
                {
                    regularRate = 80;
                    weekendRate = 80;
                    return (regularDays * regularRate + weekendDays * weekendRate);
                }
                if (name.Equals(HotelName.Bridgewood))
                {
                    regularRate = 110;
                    weekendRate = 50;
                    return (regularDays * regularRate + weekendDays * weekendRate);
                }
                if (name.Equals(HotelName.Ridgewood))
                {
                    regularRate = 100;
                    weekendRate = 40;
                    return (regularDays * regularRate + weekendDays * weekendRate);
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
            Console.Clear();
            Console.WriteLine("***********************\nHotel Name: Lakewood\nRating: 3 star\n Weekday Price: $110 per day , Weekend Price: $90 per day\n***********************");
            Console.WriteLine("***********************\nHotel Name: Bridgewood\nRating: 4 star\nPrice: $150 per day, Weekend Price: $50 per day\n***********************");
            Console.WriteLine("***********************\nHotel Name: Ridgewood\nRating: 5 star\nPrice: $220 per day, Weekend Price: $150 per day\n***********************");
        }
        /// <summary>
        ///Method to find the total number of saturdays and sundays for the given date range 
        /// </summary>
        /// <param name="checkIn">The check in.</param>
        /// <param name="checkOut">The check out.</param>
        /// <returns></returns>
        public static int WeekendCount(DateTime checkIn, DateTime checkOut)
        {
            int count = 0;
            int days = Convert.ToInt32((checkOut - checkIn).TotalDays);
            for (var i = 0; i <= days; i++)
            {
                var testDate = checkIn.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday)
                    count++;
                if (testDate.DayOfWeek == DayOfWeek.Sunday)
                    count++;
            }
            return count;
        }
        /// <summary>
        /// Method to calculate the number of days excluding saturday and sunday in the given date range
        /// </summary>
        /// <param name="checkIn">The check in.</param>
        /// <param name="checkOut">The check out.</param>
        /// <returns></returns>
        public static int WeekdaysCount(DateTime checkIn, DateTime checkOut)
        {
            int totalNumberofDays = Convert.ToInt32((checkOut - checkIn).TotalDays) + 1;
            int weekdays = totalNumberofDays - WeekendCount(checkIn, checkOut);
            return weekdays;
        }
    }
}
