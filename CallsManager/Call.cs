namespace CallsManager
{
    using System;

    public class Call
    {
        public DateTime CallDateTime { get; set; }

        public string DialedPhoneNumber { get; set; }

        public uint DurationInSeconds { get; set; }
    }
}
