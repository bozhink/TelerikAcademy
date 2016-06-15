namespace Devices.Tests
{
    using System;

    public class GSMTest
    {
        public void DevicesTest()
        {
            GSM[] phoneArray =
            {
                new GSM("6S", "Apple","Pesho1", 800.0m,  new Battery("6S battery", 72, 48, BatteryType.NiCd), new Display("5.5in", 16000000)),
                new GSM("S7", "Samsung", "Pesho2",700.0m,  new Battery("S7 battery", 48, 24, BatteryType.LiIon), new Display("5.7in", 16000000)),
                new GSM("5", "Samsung", "Super Pesho",650.0m,  new Battery("5 battery", 60, 36, BatteryType.NiMH), new Display("5.9in", 15000000)),
                new GSM("XX", "Fake Inc.")
            };

            foreach (var phone in phoneArray)
            {
                Console.WriteLine("{0}\n\n", phone);
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
