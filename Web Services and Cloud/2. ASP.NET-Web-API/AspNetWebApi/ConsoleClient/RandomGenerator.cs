namespace RandomGenerator
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private static Random random = null;

        private RandomGenerator()
        {
            object lockRandom = new object();
            if (RandomGenerator.random == null)
            {
                lock (lockRandom)
                {
                    if (RandomGenerator.random == null)
                    {
                        RandomGenerator.random = new Random();
                    }
                }
            }
        }

        public static RandomGenerator Instance
        {
            get
            {
                object lockInstance = new object();
                if (RandomGenerator.instance == null)
                {
                    lock (lockInstance)
                    {
                        if (RandomGenerator.instance == null)
                        {
                            RandomGenerator.instance = new RandomGenerator();
                        }
                    }
                }

                return RandomGenerator.instance;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return RandomGenerator.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }
    }
}
