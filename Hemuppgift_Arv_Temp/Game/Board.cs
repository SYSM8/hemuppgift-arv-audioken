namespace Hemuppgift_Arv_Temp.Game
{
    // Spelbrädet
    public class Board
    {
        // Antal pinnar
        public int NoPins { get; set; }

        // Initierar antalet pinnar
        public void SetUp(int initialPins)
        {
            NoPins = initialPins;
        }

        // Subtraherar borttagna pinnar
        public void TakePins(int takePins)
        {
            NoPins -= takePins;
        }

        // Returnerar antal pinnar
        public int GetNoPins()
        {
            return NoPins;
        }
    }
}
