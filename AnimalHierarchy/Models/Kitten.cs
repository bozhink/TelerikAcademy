namespace AnimalHierarchy.Models
{
    public class Kitten : Cat
    {
        public Kitten(string name, decimal age)
            : base(name, age, Sex.Female)
        {
        }
    }
}
