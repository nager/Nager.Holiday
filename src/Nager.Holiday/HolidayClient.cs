using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nager.Holiday
{
    public class HolidayClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _disposeHttpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public HolidayClient(
            string holidayServiceBaseUrl = "https://date.nager.at",
            HttpClient? httpClient = default)
        {
            if (httpClient == default)
            {
                httpClient = new HttpClient();
                this._disposeHttpClient = true;
            }

            httpClient.BaseAddress = new Uri(holidayServiceBaseUrl);

            this._httpClient = httpClient;

            this._jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposeHttpClient)
            {
                this._httpClient.Dispose();
            }
        }

        public async Task<PublicHoliday[]?> GetHolidaysAsync(int year, string countryCode)
        {
            using var httpResponse = await this._httpClient.GetAsync($"api/v3/publicholidays/{year}/{countryCode}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                return Array.Empty<PublicHoliday>();
            }

            using var jsonStream = await httpResponse.Content.ReadAsStreamAsync();
            return JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, this._jsonSerializerOptions);
        }
    }
}
