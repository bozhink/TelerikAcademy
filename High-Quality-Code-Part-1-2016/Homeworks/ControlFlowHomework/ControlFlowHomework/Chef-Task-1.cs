namespace ControlFlowHomework
{
    /// <summary>
    /// Task 1. Class Chef in C#
    /// Refactor the following class using best practices for organizing straight-line code
    /// </summary>
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            
            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }

        private void Cut(Vegetable vegetable)
        {
            // ...
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            
            // ... 
            return bowl;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            
            // ...
            return carrot;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            
            // ...
            return potato;
        }
    }
}
