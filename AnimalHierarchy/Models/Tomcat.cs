namespace AnimalHierarchy.Models
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, decimal age)
            : base(name, age, Sex.Male)
        {
        }
    }
}
