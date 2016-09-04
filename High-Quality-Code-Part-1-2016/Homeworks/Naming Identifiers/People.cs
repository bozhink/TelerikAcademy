/// <summary>
/// Task 2. Make_Чуек in C#
/// Refactor the following examples to produce code with well-named C# identifiers.
/// </summary>
namespace NamingIdentifiersHomework
{
    using System;
    using System.Collections.Generic;

    public class People
    {
        public List<Person> peopleList;

        public enum Gender
        {
            Male,
            Female
        };

        public class Person
        {
            public Gender Sex { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public People()
        {
            peopleList = new List<Person>();
        }

        public void MakePerson(int age)
        {
            var person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Gender.Female;
            }

            peopleList.Add(person);
        }
    }
}
