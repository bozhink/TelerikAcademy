namespace Methods
{
    using System;

    public class Digit
    {
        public static string ToString(int number)
        {
            string digitToString = string.Empty;

            switch (number)
            {
                case 0:
                    digitToString = "zero";
                    break;
                case 1:
                    digitToString = "one";
                    break;
                case 2:
                    digitToString = "two";
                    break;
                case 3:
                    digitToString = "three";
                    break;
                case 4:
                    digitToString = "four";
                    break;
                case 5:
                    digitToString = "five";
                    break;
                case 6:
                    digitToString = "six";
                    break;
                case 7:
                    digitToString = "seven";
                    break;
                case 8:
                    digitToString = "eight";
                    break;
                case 9:
                    digitToString = "nine";
                    break;
                default:
                    throw new Exception("Entered number is not a digit.");
            }

            return digitToString;
        }
    }
}
