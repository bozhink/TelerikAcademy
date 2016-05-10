namespace RandomGenerator
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);
    }
}
