namespace StudentTests
{
    using System;
    using System.Linq;
    using LinqProblems;
    using LinqProblems.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            var students = Enumerable.Range(0, 10)
                .Select(i => new Student
                {
                    FirstName = i.ToString(),
                    LastName = i.ToString(),
                    GroupNumber = (uint)i
                })
                .ToList();

            var studentGroups = new StudentGroups();
            studentGroups.GetStudentsInGroup(students)
                .ToList()
                .ForEach(s => Console.WriteLine(s.GroupNumber));
        }
    }
}
