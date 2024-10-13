namespace Hemuppgift_Arv_Temp.Game
{
    // Underklass för människostyrd spelare
    public class HumanPlayer : Player
    {
        // Ärver spelarnamnet från "Player"
        public HumanPlayer(string userID) : base(userID) { }

        // Användaren väljer antal pinnar att ta bort
        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar borttagna pinnar
            int remainingPins = board.GetNoPins(); // Lagrar återstående pinnar

            bool correctInput = false; // Kontroll för giltig inmatning

            // Användarval som itererar tills giltig inmatning sker
            do
            {
                Console.Write("Ta bort 1 eller 2 pinnar? ");

                // Läser in inmatning
                switch (Console.ReadLine())
                {
                    // Ta bort en pinne
                    case "1":
                        removedPins = 1;
                        correctInput = true; // Avbryt menyloop
                        break;

                    // Ta bort två pinnar
                    case "2":

                        // Ta endast bort två pinnar om det går
                        if (remainingPins > 1)
                        {
                            removedPins = 2;
                            correctInput = true; // Avbryt menyloop
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDet finns endast en pinne kvar..\n");
                            Console.ResetColor();
                        }
                        break;

                    // Varningsmeddelande vid felaktigt menyval. Iterera igen.
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..\n");
                        Console.ResetColor();
                        break;
                }

            } while (!correctInput);

            // Subtraherar pinnar från spelbrädet
            board.TakePins(removedPins);

            // Returnera borttaget antal
            return removedPins;
        }
    }
}
