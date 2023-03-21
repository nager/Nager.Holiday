using System;

namespace Nager.Holiday
{
    /// <summary>
    /// Holiday Client Exception
    /// </summary>
    public class HolidayClientException : Exception
    {
        /// <summary>
        /// Holiday Client Exception
        /// </summary>
        public HolidayClientException()
        {
        }

        /// <summary>
        /// Holiday Client Exception
        /// </summary>
        /// <param name="message"></param>
        public HolidayClientException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Holiday Client Exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public HolidayClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
