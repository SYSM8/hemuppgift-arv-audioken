namespace Hemuppgift_Arv_Temp.Game
{
    // Underklass för datorstyrd spelare
    public class ComputerPlayer : Player
    {
        // Ärver spelarnamnet från "Player"
        public ComputerPlayer(string userID) : base(userID) { }

        // Enkel algoritm för att ta bort pinnar
        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar borttagna pinnar
            int remainingPins = board.GetNoPins(); // Lagrar återstående pinnar

            Random rnd = new Random(); // Objekt för randomisering

            // Finns fler än två - Slumpa 1-2
            if (remainingPins > 2)
                removedPins = rnd.Next(1, 3);

            // Annars ta bort de som återstår
            else if (remainingPins == 2)
                removedPins = 2;
            else
                removedPins = 1;

            // Subtraherar pinnar från spelbrädet
            board.TakePins(removedPins);

            return removedPins; // Returnera borttaget antal
        }
    }
}
