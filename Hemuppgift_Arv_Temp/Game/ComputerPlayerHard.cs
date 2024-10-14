namespace Hemuppgift_Arv_Temp.Game
{
    // Underklass för svårare datorstyrd spelare
    public class ComputerPlayerHard : Player
    {
        // Ärver spelarnamnet från "Player"
        public ComputerPlayerHard(string userID) : base(userID) { }

        // Smartare algoritm för att ta bort pinnar
        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar borttagna pinnar
            int remainingPins = board.GetNoPins(); // Lagrar återstående pinnar

            Random rnd = new Random(); // Objekt för randomisering

            // Försöker alltid sätta motståndaren på ett tal delbart med 3 för att säkra vinst
            if (remainingPins % 3 == 1)
                removedPins = 1; // Är restdivision 1 - Ta bort 1

            else if (remainingPins % 3 == 2)
                removedPins = 2; // Är restdivision 2 - Ta bort 2

            else
                removedPins = rnd.Next(1, 3); // Annars slumpa mellan 1-2

            // Subtraherar pinnar från spelbrädet
            board.TakePins(removedPins);

            return removedPins; // Returnera borttaget antal till main
        }
    }
}
