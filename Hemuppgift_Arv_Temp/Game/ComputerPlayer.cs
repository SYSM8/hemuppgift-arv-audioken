namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayer : Player
    {
        // Konstruktor som ärver sin parameter för spelarnamn från superklassen Player
        public ComputerPlayer(string userID) : base(userID) { }

        // Den datorbaserade spelaren väljer hur många pinnar de vill ta bort
        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar det antal pinnar ComputerPlayer tar bort
            int remainingPins = board.GetNoPins(); // Hämtar antalet återstående pinnar

            // Skapar ett nytt objekt för att slumpa nummer
            Random rnd = new Random();

            // Slumpar mellan 1-2 sålänge minst 2 pinnar finns kvar
            if (remainingPins > 1)
                removedPins = rnd.Next(1, 3); // Slumpar mellan 1-2

            else
                removedPins = 1; // Ta bort en pinne om det bara finns en kvar

            // Anropar metod i klassen Board för att subtrahera det valda antalet
            board.TakePins(removedPins);

            return removedPins; // Returnera borttaget antal till main
        }
    }
}
