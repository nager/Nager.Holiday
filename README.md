[![GitHub Sponsors](https://img.shields.io/github/sponsors/nager?style=for-the-badge&color=000)](https://github.com/sponsors/nager)
[![GitHub License](https://img.shields.io/github/license/nager/Nager.Holiday?style=for-the-badge&color=000)](https://github.com/nager/Nager.Holiday)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/nager/Nager.Holiday/dotnet.yml?style=for-the-badge&color=000)](https://github.com/nager/Nager.Holiday)

# Nager.Holiday

**Nager.Holiday** is the official .NET client for [Nager.Date](https://date.nager.at), a popular project for querying public holidays worldwide. It allows you to easily retrieve holiday data for **100+ countries** via the API.
> ⚠️ **Commercial use requires sponsorship.** Support the project [here](https://github.com/sponsors/nager).

## 🌍 Supported Countries
The full list of supported countries can be found [here](https://date.nager.at/Country/Coverage).

## 📦 Installation

The NuGet package is available via [NuGet](https://www.nuget.org/packages/Nager.Holiday)

```powershell
PM> install-package Nager.Holiday
```

## 💡 Usage Examples

### Retrieve All Public Holidays for a Specific Country and Year
```cs
using var holidayClient = new HolidayClient();
var holidays = await holidayClient.GetHolidaysAsync(2022, "br");

foreach (var holiday in holidays)
{
    //holiday...
    //holiday.Date -> The date
    //holiday.LocalName -> The local name
    //holiday.Name -> The english name
    //holiday.Global -> Is this public holiday in every county (federal state)
    //holiday.Counties -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //holiday.Type -> Public, Bank, School, Authorities, Optional, Observance
}
```
## ✅ Key Features
- Retrieve holidays for 100+ countries
- Supports subdivisions (states or regions) where available
- Easy-to-use .NET API client
- Commercial usage requires sponsorship
