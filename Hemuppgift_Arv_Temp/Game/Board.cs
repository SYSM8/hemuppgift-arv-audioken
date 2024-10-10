namespace Hemuppgift_Arv_Temp.Game
{
    public class Board
    {
        // Egenskap som håller koll på antalet pinnar i spelet
        public int NoPins { get; set; }

        // Metod som ställer in antalet pinnar vid spelets start
        public void SetUp(int initialPins)
        {
            NoPins = initialPins; // Lagrar det skickade värdet i egenskapen NoPins
        }

        // Metod som tar bort pinnar från det totala antalet
        public void TakePins(int takePins)
        {
            NoPins -= takePins; // Subtraherar det skickade värdet för egenskapen NoPins
        }

        // Metod som returnerar antalet pinnar som finns kvar i spelet
        public int GetNoPins()
        {
            return NoPins;
        }
    }
}
