namespace ControlFlowHomework
{
    public class Chess
    {
        private const int MinimalValueOfX = 1;
        private const int MaximalValueOfX = 8;
        private const int MinimalValueOfY = 1;
        private const int MaximalValueOfY = 8;

        public void VisitCellIfPossible(int x, int y, bool canVisitCell)
        {
            if (canVisitCell && 
                (MinimalValueOfX <= x) && (x <= MaximalValueOfX) && 
                (MinimalValueOfY <= y) && (y <= MaximalValueOfY))
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            // ...
        }
    }
}
