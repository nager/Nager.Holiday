# Nager.Holiday

An official .NET client for [Nager.Date](https://date.nager.at), the popular public holiday API. Easily query worldwide public holidays, long weekends, and country info for **150+ countries**.

[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/nager/Nager.Holiday/dotnet.yml?style=for-the-badge&color=24292e)](https://github.com/nager/Nager.Holiday)
[![GitHub License](https://img.shields.io/github/license/nager/Nager.Holiday?style=for-the-badge&color=24292e)](https://github.com/nager/Nager.Holiday)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/nager?style=for-the-badge&color=db61a2)](https://github.com/sponsors/nager)

---

> [!IMPORTANT]
> **Commercial use requires sponsorship.** > If you use this library in a commercial product, please support the ongoing maintenance and data updates by [becoming a GitHub Sponsor](https://github.com/sponsors/nager).

---

## ✨ Key Features

- **Global Coverage:** Retrieve public holidays for over 150+ countries.
- **Regional Support:** Supports subdivisions (states, regions, counties via ISO-3166-2) where available.
- **Modern .NET client:** Fully async, lightweight, and easy to integrate.
- **Detailed Holiday Types:** Differentiates between Public, Bank, School, Authorities, Optional, and Observance.

## 📦 Installation

Install the package via the [NuGet Package Manager Console](https://www.nuget.org/packages/Nager.Holiday):

```powershell
Install-Package Nager.Holiday

```

Or via the .NET CLI:

```bash
dotnet add package Nager.Holiday

```

---

## 💡 Usage Example

### Retrieve Public Holidays for a Country

```csharp
using Nager.Holiday;

using var holidayClient = new HolidayClient();
// Fetch holidays for Brazil (BR) in 2026
var holidays = await holidayClient.GetHolidaysAsync(2026, "br");

foreach (var holiday in holidays)
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd}: {holiday.Name}");
    // Available properties:
    // holiday.NationalHoliday    ->    bool (Indicates if this holiday applies to the entire country)
    // holiday.SubdivisionCodes   ->    string[] (ISO-3166-2 codes of the subdivisions where this holiday applies)
    // holiday.HolidayTypes       ->    List of holiday types this holiday is classified under (Public, Bank, School, Authorities, Optional, Observance)
}

```

---

## 🌍 Supported Countries

The complete and up-to-date list of all supported countries and their current API coverage can be found on the [Nager.Date Coverage Page](https://date.nager.at/country/coverage).