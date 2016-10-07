namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Contracts;
    using Models;

    internal class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // I have faith in you
        public Engine(ConsoleReader readed)
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
                    this.WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        private ConsoleReader read;

        private void WriteLine(string m)
        {
            var p = m.Split();
            var s = string.Join(" ", p);
            var c = 0d;
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

        internal static Dictionary<int, Teacher> teachers { get; set; } = new Dictionary<int, Teacher>();

        internal static Dictionary<int, Student> students { get; set; } = new Dictionary<int, Student>();
    }
}
