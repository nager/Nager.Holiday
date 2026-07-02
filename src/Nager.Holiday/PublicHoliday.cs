using System;

namespace Nager.Holiday
{
    /// <summary>
    /// Public Holiday
    /// </summary>
    public class PublicHoliday
    {
        /// <summary>
        /// The date of the holiday
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// English name of the holiday
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Indicates if this holiday applies to the entire country
        /// </summary>
        public bool NationalHoliday { get; set; }

        /// <summary>
        /// ISO-3166-2 codes of the subdivisions where this holiday applies
        /// </summary>
        public string[]? SubdivisionCodes { get; set; }

        /// <summary>
        /// A list of types the public holiday it is valid
        /// </summary>
        public PublicHolidayType[]? HolidayTypes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} - {this.Name}";
        }
    }
}
