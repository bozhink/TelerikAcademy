namespace Events.Contracts
{
    public interface ILogger
    {
        void Append(string value);

        void AppendFormat(string format, params object[] values);
    }
}
