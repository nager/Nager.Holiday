using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Nager.Holiday
{
    /// <summary>
    /// Holiday Client
    /// </summary>
    public class HolidayClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _disposeHttpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Holiday Client
        /// </summary>
        /// <param name="holidayServiceBaseUrl"></param>
        /// <param name="httpClient"></param>
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

        /// <summary>
        /// Get Holidays for given year and country
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PublicHoliday[]?> GetHolidaysAsync(
            int year,
            string countryCode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using var httpResponse = await this._httpClient.GetAsync($"api/v3/publicholidays/{year}/{countryCode}", cancellationToken);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var json = await httpResponse.Content.ReadAsStringAsync();
                        throw new HolidayClientException(json);
                    }

                    throw new HolidayClientException($"StatusCode:{httpResponse.StatusCode}");
                }

                using var jsonStream = await httpResponse.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, this._jsonSerializerOptions);
            }
            catch (TaskCanceledException)
            {
                return Array.Empty<PublicHoliday>();
            }
        }
    }
}
