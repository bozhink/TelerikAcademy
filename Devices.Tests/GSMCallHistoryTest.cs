namespace Devices.Tests
{
    using System;
    using System.Linq;
    using CallsManager;

    public class GSMCallHistoryTest
    {
        public void RunGSMCallHistoryTest()
        {
            var phone = new GSM("Model", "Manufacturer", "Pesho", 200000.0m, new Battery("Fake battery", 5000, 1000, BatteryType.Other), new Display("50.0in", 3));
            phone.AddCall(new Call
            {
                CallDateTime = DateTime.UtcNow,
                DialedPhoneNumber = "000-000-000-000",
                DurationInSeconds = 10
            });

            phone.AddCall(new Call
            {
                CallDateTime = DateTime.UtcNow,
                DialedPhoneNumber = "666-666-666-666",
                DurationInSeconds = 66
            });

            phone.AddCall(new Call
            {
                CallDateTime = DateTime.UtcNow,
                DialedPhoneNumber = "888-888-888-888",
                DurationInSeconds = 88
            });

            Console.WriteLine(phone);

            PrintCallHistory(phone);

            Console.WriteLine("Price: {0:f2}.", phone.TotalPriceOfCalls(0.37m));

            var maximalDurationOfCall = phone.CallHistory.Max(c => c.DurationInSeconds);
            var longestCall = phone.CallHistory.FirstOrDefault(c => c.DurationInSeconds == maximalDurationOfCall);
            Console.WriteLine("Longest call duration: {0} s.", longestCall.DurationInSeconds);

            phone.DeleteCall(longestCall);
            PrintCallHistory(phone);

            phone.ClearCallHistory();
            PrintCallHistory(phone);
        }

        private static void PrintCallHistory(GSM phone)
        {
            Console.WriteLine("\nAll calls:");
            Console.WriteLine(string.Join(" | ", phone.CallHistory.Select(c => c.DialedPhoneNumber).ToList()));
            Console.WriteLine();
        }
    }
}
