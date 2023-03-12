namespace Nager.Holiday
{
    /// <summary>
    /// The type of a public holiday
    /// </summary>
    public enum PublicHolidayType
    {
        /// <summary>
        /// Public holiday
        /// </summary>
        Public,
        /// <summary>
        /// Bank holiday, banks and offices are closed
        /// </summary>
        Bank,
        /// <summary>
        /// School holiday, schools are closed
        /// </summary>
        School,
        /// <summary>
        /// Authorities are closed
        /// </summary>
        Authorities,
        /// <summary>
        /// Majority of people take a day off
        /// </summary>
        Optional,
        /// <summary>
        /// Optional festivity, no paid day off
        /// </summary>
        Observance,
    }
}
