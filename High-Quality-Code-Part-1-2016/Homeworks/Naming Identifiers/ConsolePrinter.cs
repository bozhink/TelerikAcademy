/// <summary>
/// Task 1. class_123 in C#
/// Refactor the following examples to produce code with well-named C# identifiers.
/// </summary>
namespace NamingIdentifiersHomework
{
    using System;

    public class ConsolePrinter
    {
        private const int MaxCount = 6;

        public static void PrintTrue()
        {
            var printer = new ConsolePrinter.GeneralPrintMethods();
            printer.PrintBooleanToConsole(true);
        }

        private class GeneralPrintMethods
        {
            public void PrintBooleanToConsole(bool toBePrinted)
            {
                string toBePrintedAsString = toBePrinted.ToString();
                Console.WriteLine(toBePrintedAsString);
            }
        }
    }
}
