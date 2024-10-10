namespace Hemuppgift_Arv_Temp.Game
{
    public class Board
    {
        // Egenskap som håller koll på antalet pinnar i spelet
        public int NoPins { get; set; }

        // Anger startvärdet för "NoPins"
        public void SetUp(int initialPins)
        {
            NoPins = initialPins;
        }

        // Subtraherar parametervärdet från "NoPins"
        public void TakePins(int takePins)
        {
            NoPins -= takePins;
        }

        // Returnerar värdet från "NoPins"
        public int GetNoPins()
        {
            return NoPins;
        }
    }
}
