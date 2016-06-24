namespace AnimalHierarchy.Models
{
    public class Frog : Animal
    {
        public Frog(string name, decimal age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Frog sound";
        }
    }
}
