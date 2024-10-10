namespace Hemuppgift_Arv_Temp.Game
{
    public class HumanPlayer : Player
    {
        // Konstruktor som ärver sin parameter för spelarnamn från superklassen Player
        public HumanPlayer(string userID) : base(userID) { }

        // Den mänskliga spelaren väljer hur många pinnar de vill ta bort
        public override int TakePins(Board board)
        {
            // Tillfällig kod för testning
            int removedPins = 2;

            board.TakePins(removedPins);

            return removedPins;
        }
    }
}
