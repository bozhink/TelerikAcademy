namespace StringBuilder.Substring
{
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder, int index)
        {
            return new StringBuilder(stringBuilder?.ToString().Substring(index));
        }

        public static StringBuilder Substring(this StringBuilder stringBuilder, int index, int length)
        {
            return new StringBuilder(stringBuilder?.ToString().Substring(index, length));
        }
    }
}
