namespace SchoolSystem.Core
{
    public class IdGenerator
    {
        private int id = 0;

        public int Next()
        {
            return this.id++;
        }
    }
}
