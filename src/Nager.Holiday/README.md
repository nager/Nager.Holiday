# Nager.Holiday

Nager.Holiday is the client for [Nager.Date](https://date.nager.at), a popular project for querying holidays.

## Country Support
The list of supported countries can be found [here](https://date.nager.at/country/coverage)

## Examples

### Get all holidays of a country and year
```cs
using var holidayClient = new HolidayClient();
var holidays = await holidayClient.GetHolidaysAsync(2026, "br");

foreach (var holiday in holidays)
{
    //holiday.Date              ->    The date
    //holiday.Name              ->    The english name
    //holiday.NationalHoliday   ->    bool (Indicates if this holiday applies to the entire country)
    //holiday.SubdivisionCodes  ->    string[] (ISO-3166-2 codes of the subdivisions where this holiday applies)
    //holiday.HolidayTypes      ->    List of holiday types this holiday is classified under (Public, Bank, School, Authorities, Optional, Observance)
}
```
