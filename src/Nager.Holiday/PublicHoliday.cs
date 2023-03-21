using System;

namespace Nager.Holiday
{
    /// <summary>
    /// Public Holiday
    /// </summary>
    public class PublicHoliday
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Local name
        /// </summary>
        public string? LocalName { get; set; }
        /// <summary>
        /// English name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ISO 3166-1 alpha-2
        /// </summary>
        public string? CountryCode { get; set; }
        /// <summary>
        /// Is this public holiday every year on the same date
        /// </summary>
        public bool Fixed { get; set; }
        /// <summary>
        /// Is this public holiday in every county (federal state)
        /// </summary>
        public bool Global { get; set; }
        /// <summary>
        /// ISO-3166-2 - Federal states
        /// </summary>
        public string[]? Counties { get; set; }
        /// <summary>
        /// A list of types the public holiday it is valid
        /// </summary>
        public PublicHolidayType[]? Types { get; set; }
        /// <summary>
        /// The launch year of the public holiday
        /// </summary>
        public int? LaunchYear { get; set; }
    }
}
