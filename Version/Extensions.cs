namespace Version
{
    using System;
    using System.Linq;

    public static class Extensions
    {
        public static string GetVersion(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var version = type.GetCustomAttributes(false).FirstOrDefault(a => a.GetType() == typeof(VersionAttribute)) as VersionAttribute;

            return version.ToString();
        }

        public static string GetVersion<T>(this T obj)
        {
            return GetVersion(typeof(T));
        }
    }
}
