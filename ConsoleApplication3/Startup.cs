namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Contracts;

    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at least 2 more provider like this one
            var padhana = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(padhana);
        }
    }

    public class ConsoleReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string PadhanaLine()
        {
            return Console.ReadLine();
        }
    }

    public class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // I have faith in you
        public Engine(ConsoleReaderProvider readed)
        {
            read = readed;
        }

        public void BrumBrum()
        {
            while (true)
            {
                try
                {
                    var cmd = Console.ReadLine();
                    if (cmd == "End")
                    {
                        break;
                    }

                    var aadeshName = cmd.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembli = GetType().GetTypeInfo().Assembly;
                    var tpyeinfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(aadeshName.ToLower()))
                        .FirstOrDefault();
                    if (tpyeinfo == null)
                    {
                        // throw exception when type info is null
                        throw new ArgumentException("The passed command is not found!");
                    }
                    var aadesh = Activator.CreateInstance(tpyeinfo) as ICommand;
                    var paramss = cmd.Split(' ').ToList();
                    paramss.RemoveAt(0);
                    WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        private ConsoleReaderProvider read;

        void WriteLine(string m)
        {
            var p = m.Split(); var s = string.Join(" ", p); var c = 0d;
            for (double i = 0; i < 0x105; i++)
            {
                try
                {
                    Console.Write(s[int.Parse(i.ToString())]);
                }
                catch (Exception)
                {
                    //who cares?
                }
            }

            Console.Write("\n");
            Thread.Sleep(350);
        }

        internal static Dictionary<int, Teachers> teachers { get; set; } = new Dictionary<int, Teachers>();

        internal static Dictionary<int, Student> students { get; set; } = new Dictionary<int, Student>();
    }
}
