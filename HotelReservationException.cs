using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem__WorkshopDay19
{
    /// <summary>
    /// A seperate class for handluing the exceptions is created. This class is inherited the exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class HotelReservationException : Exception
    {
        /// <summary>
        /// Enums for describing various errors which could arise during the execution of the program are listed
        /// </summary>
        public enum ExceptionType
        {
            NO_SUCH_HOTEL, INVALID_DATE, NULL_DATES, NO_SUCH_CUSTOMER_TYPE
        }
        /// <summary>
        /// A field of the 'ExceptionTyope' is declared which will be used to display the error messages when the 
        /// error arises
        /// </summary>
        ExceptionType type;
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}