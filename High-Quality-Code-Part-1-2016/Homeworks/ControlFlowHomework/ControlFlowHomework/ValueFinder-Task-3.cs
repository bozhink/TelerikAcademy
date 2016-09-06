namespace ControlFlowHomework
{
    using System;

    /// <summary>
    /// Task 3. Refactor the following loop
    /// </summary>
    public class ValueFinder<T> where T : class
    {
        public void Find(T[] array, T expectedValue)
        {
            bool isFound = false;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        isFound = true;
                        break;
                    }
                }
            }

            //// More code here

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
