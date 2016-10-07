namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        // This code sucks, you know it and I know it.
        // Move on and call me an idiot later.
        public string fNeim; public Grade grads; public List<Mark> mark; public string lNeim;

        private Student(string _, string __, Grade ___)
        { fNeim = _; lNeim = __; grads = ___; mark = new List<Mark>(); }

        public string ListMarks()
        {
            var potatos = mark.Select(m => $"{m.subject} => {m.value}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
