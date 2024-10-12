namespace Hemuppgift_Arv_Temp.Game
{
    public class HumanPlayer : Player
    {
        // Konstruktor som ärver sin parameter för spelarnamn från superklassen Player
        public HumanPlayer(string userID) : base(userID) { }

        // Den mänskliga spelaren väljer hur många pinnar de vill ta bort
        public override int TakePins(Board board)
        {
            int removedPins = 0; // Lagrar det antal pinnar användaren vill ta bort
            int remainingPins = board.GetNoPins(); // Hämtar antalet återstående pinnar
            bool correctInput = false; // Kontroll för giltig inmatning

            do
            {
                Console.Write("\nTa bort [1] eller [2] pinnar? ");

                switch (Console.ReadLine())
                {
                    case "1":
                        removedPins = 1;
                        correctInput = true;
                        break;

                    case "2":
                        if (remainingPins > 1)
                        {
                            removedPins = 2;
                            correctInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDet finns endast en pinne kvar..");
                            Console.ResetColor();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..");
                        Console.ResetColor();
                        break;
                }

            } while (!correctInput);

            // Anropar metod i klassen Board för att subtrahera det valda antalet
            board.TakePins(removedPins);

            // Returnera borttaget antal till main
            return removedPins;
        }
    }
}
