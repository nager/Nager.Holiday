# Nager.Date

Nager.Date is a popular project to query holidays. We currently support over 100 countries.

## Country Support
The list of supported countries can be found [here](https://date.nager.at/Country/Coverage)

## Examples

### Get all publicHolidays of a country and year
```cs
using var holidayClient = new HolidayClient();
var holidays = await holidayClient.GetHolidaysAsync(2022, "br");

foreach (var holiday in holidays)
{
    //holiday...
    //holiday.Date -> The date
    //holiday.LocalName -> The local name
    //holiday.Name -> The english name
    //holiday.Fixed -> Is this public holiday every year on the same date
    //holiday.Global -> Is this public holiday in every county (federal state)
    //holiday.Counties -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //holiday.Type -> Public, Bank, School, Authorities, Optional, Observance
}
```
