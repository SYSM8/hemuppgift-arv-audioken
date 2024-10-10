namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayer : Player
    {
        // Konstruktor som ärver sin parameter för spelarnamn från superklassen Player
        public ComputerPlayer(string userID) : base(userID) { }

        // Den datorbaserade spelaren väljer hur många pinnar de vill ta bort
        public override int TakePins(Board board)
        {
            int removedPins = 0;

            Random rnd = new Random();
            removedPins = rnd.Next(1, 2);

            board.TakePins(removedPins);

            return removedPins;
        }
    }
}
