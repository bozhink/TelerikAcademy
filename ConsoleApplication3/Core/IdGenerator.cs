namespace SchoolSystem.Core
{
    public static class IdGenerator
    {
        private static int id = 0;

        public static int Next()
        {
            return id++;
        }
    }
}
