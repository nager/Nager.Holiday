namespace Nager.Holiday.UnitTest
{
    [TestClass]
    public class HolidayTest
    {
        [TestMethod]
        public async Task GetHolidaysAsync_Brazil2022_Successful()
        {
            using var holidayClient = new HolidayClient();
            var holidays = await holidayClient.GetHolidaysAsync(2022, "br");
            Assert.IsNotNull(holidays);
            Assert.IsTrue(holidays.Length > 0);
        }
    }
}