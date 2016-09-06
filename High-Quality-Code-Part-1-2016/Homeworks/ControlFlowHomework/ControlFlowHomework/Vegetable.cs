namespace ControlFlowHomework
{
    /// <summary>
    /// Vegetable - a base class for all vegetable.
    /// </summary>
    public class Vegetable
    {
        private bool isPeeled;
        private bool isRotten;

        public Vegetable()
        {
            this.isPeeled = false;
            this.isRotten = false;
        }

        public bool HasBeenPeeled
        {
            get
            {
                return this.isPeeled;
            }
        }

        public bool IsRotten
        {
            get
            {
                return this.isRotten;
            }
        }
    }
}
