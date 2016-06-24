namespace AnimalHierarchy.Models
{
    public class Dog : Animal
    {
        public Dog(string name, decimal age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Dog sound";
        }
    }
}
