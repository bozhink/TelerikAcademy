namespace Devices.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gsmTests = new GSMTest();
            gsmTests.DevicesTest();

            var callTests = new GSMCallHistoryTest();
            callTests.RunGSMCallHistoryTest();
        }
    }
}
