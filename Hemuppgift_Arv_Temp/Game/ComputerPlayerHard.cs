namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayerHard : Player
    {
        public ComputerPlayerHard(string userID) : base(userID) { }

        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar det antal pinnar ComputerPlayer tar bort
            int remainingPins = board.GetNoPins(); // Hämtar antalet återstående pinnar

            Random rnd = new Random();

            if (remainingPins % 3 == 1)
            {
                removedPins = 1;
            }
            else if (remainingPins % 3 == 2)
            {
                removedPins = 2;
            }
            else
            {
                removedPins = rnd.Next(1, 3); // Slumpar mellan 1-2
            }

            board.TakePins(removedPins);

            return removedPins; // Returnera borttaget antal till main
        }
    }
}
