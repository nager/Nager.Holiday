using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Nager.Holiday.UnitTest
{
    [TestClass]
    public class HolidayClientTest
    {
        [TestMethod]
        public async Task GetHolidaysAsync_Brazil2022_Successful()
        {
            using var holidayClient = new HolidayClient();
            var holidays = await holidayClient.GetHolidaysAsync(2022, "br");
            Assert.IsNotNull(holidays);
            Assert.IsTrue(holidays.Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(HolidayClientException))]
        public async Task GetHolidaysAsync_Brazil1500_ThrowException()
        {
            using var holidayClient = new HolidayClient();
            var holidays = await holidayClient.GetHolidaysAsync(1500, "br");
        }

        [TestMethod]
        public async Task GetHolidaysAsync_CancelRequest_EmptyResponse()
        {
            using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(1));

            using var holidayClient = new HolidayClient();
            var holidays = await holidayClient.GetHolidaysAsync(2022, "br", cancellationTokenSource.Token);
        }

        [TestMethod]
        public async Task GetHolidaysAsync_UseCustomHttpClient_Successful()
        {
            using var httpClient = new HttpClient();

            using var holidayClient = new HolidayClient(httpClient: httpClient);
            var holidays = await holidayClient.GetHolidaysAsync(2022, "br");
            Assert.IsNotNull(holidays);
            Assert.IsTrue(holidays.Length > 0);
        }
    }
}