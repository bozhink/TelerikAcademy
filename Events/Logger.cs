namespace Events
{
    using System.Text;
    using Contracts;

    public class Logger : ILogger
    {
        private StringBuilder log;

        public Logger()
        {
            this.log = new StringBuilder();
        }

        public void Append(string value)
        {
            this.log.Append(value: value);
        }

        public void AppendFormat(string format, params object[] values)
        {
            this.log.AppendFormat(format: format, args: values);
        }

        public override string ToString() => this.log.ToString();
    }
}
