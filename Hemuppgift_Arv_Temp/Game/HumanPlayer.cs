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
            bool correctInput = false; // Kontroll för giltig inmatning

            do
            {
                Console.WriteLine("\nVill du ta bort [1] eller [2] pinnar?");
                Console.Write("Ditt val: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        removedPins = 1;
                        correctInput = true;
                        break;
                    case "2":
                        removedPins = 2;
                        correctInput = true;
                        break;
                    default:
                        Console.WriteLine("Du måste välja 1 eller 2..");
                        break;
                }

            } while (!correctInput);

            // Anropar metod i klassen Board för att subtrahera det valda antalet
            board.TakePins(removedPins);

            // Returnera det borttagna antalet till main
            return removedPins;
        }
    }
}
