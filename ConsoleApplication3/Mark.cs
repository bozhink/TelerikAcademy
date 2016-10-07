﻿namespace SchoolSystem
{
    using Contracts;

    public class Mark : IMark
    {
        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public float Value { get; private set; }

        public Subject Subject { get; private set; }
    }
}
