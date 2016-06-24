namespace AnimalHierarchy.Models
{
    public class Cat : Animal
    {
        public Cat(string name, decimal age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Cat sound";
        }
    }
}
