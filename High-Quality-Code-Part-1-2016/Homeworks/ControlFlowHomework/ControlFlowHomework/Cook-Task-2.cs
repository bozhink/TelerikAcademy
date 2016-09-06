namespace ControlFlowHomework
{
    /// <summary>
    /// Task 2. Refactor the following if statements
    /// </summary>
    public class CookVegetables
    {
        public void Cook(Vegetable vegetable)
        {
            // ...
        }

        public void CookPotato()
        {
            Potato potato = null;
            
            // ... 
            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    this.Cook(potato);
                }
            }
        }
    }
}
