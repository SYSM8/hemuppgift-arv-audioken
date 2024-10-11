namespace Hemuppgift_Arv_Temp.Game
{
    internal class TakePins
    {
        // SVAR PÅ FRÅGOR:
        /* 
         a) Klassen Player är ( en superklass ) till klasserna HumanPlayer och ComputerPlayer.

         b) Vilka av följande tilldelningssatser är korrekta? 
         
         Player p = new Player("Aegon");
         FEL (klassen "Player" är Abstract)

         Player p = new HumanPlayer("Alicent");
         RÄTT (klassen "HumanPlayer", som ärver från klassen "Player", används istället)

         HumanPlayer p = new HumanPlayer("Rhaenyra");
         RÄTT (Klassen "HumanPlayer" är inte abstrakt och kan därmed få sina objekt instansierade");

         HumanPlayer p = new ComputerPlayer("Aemond");
         FEL (Ingen av klasserna ärver från varandra och därför kan vi inte skapa objekt på det sättet).
        */

        static void Main(string[] args)
        {
            // Skapar objekt som behövs
            Board board = new Board();



            // Deklarerar variabler för att öka läsbarheten i utskrifter
            int removedPins = 0;
            int remainingPins = 0;

            // Vinstkontroll när någon vunnit
            bool didUserWin = false;

            // Välkomnar användaren med instruktioner
            Console.WriteLine("Välkommen till Pinn or Loose!");

            Console.WriteLine("\nSpelet går ut på att det ligger ett antal stickor på ett bord. " +
                              "\nTvå spelare turas om att ta stickor. Man får ta en eller två stickor. " +
                              "\nDen som tar sista stickan vinner.");

            Console.Write("\nVad heter du?: ");

            // Skapar ett objekt för HumanPlayer och lagrar användarens inmatade namn
            Player human = new HumanPlayer(Console.ReadLine());

            // Lagrar namnet i ny variabel för tydligare utskrifter
            string humanName = human.GetUserID();

            Console.WriteLine($"\nTack {humanName}!");

            // Skapar objekt för datormotståndare som är satt till null i väntan på menyval av svårighetsgrad
            Player cpu = null;

            bool correctInput = false; // Kontroll för giltig inmatning

            do
            {
                Console.WriteLine("\nVälj motståndarens svårighetsgrad.");

                Console.WriteLine("\n[1] 3-CPO (Lätt) | [2] Deep Thought (Svår)");

                switch (Console.ReadLine())
                {
                    case "1":
                        cpu = new ComputerPlayer("3-CPO");
                        correctInput = true;
                        break;

                    case "2":
                        cpu = new ComputerPlayerHard("Deep Thought");
                        correctInput = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..");
                        Console.ResetColor();
                        break;
                }
            } while (!correctInput);

            // Lagrar namnet i ny variabel för tydligare utskrifter
            string cpuName = cpu.GetUserID();

            Console.WriteLine($"\nTack {humanName}! Du har valt att möta {cpuName}\nHur många pinnar vill du att spelet ska ha?");

            correctInput = false;

            do
            {
                Console.Write("\nVälj mellan 10-30: ");

                if (int.TryParse(Console.ReadLine(), out remainingPins) && remainingPins >= 10 && remainingPins <= 30)
                {
                    board.SetUp(remainingPins);
                    correctInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste välja ett antal mellan 10-30..");
                    Console.ResetColor();
                }
            } while (!correctInput);

            Console.WriteLine($"\nTack {humanName}! Antal pinnar i spelet är {remainingPins} st");
            Console.WriteLine($"Matchen mellan {humanName} och {cpuName} kan börja!");

            Console.WriteLine($"\nDet finns totalt {remainingPins} pinnar i spelet");

            Console.WriteLine("\nDu börjar..");

            while (remainingPins != 0)
            {
                // HumanPlayer spelar..
                removedPins = human.TakePins(board);
                remainingPins = board.GetNoPins();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{humanName} har tagit bort {removedPins} pinnar!");
                Console.ResetColor();

                if (remainingPins == 0)
                {
                    didUserWin = true;
                    break;
                }
                else { Console.WriteLine($"\nDet finns {remainingPins} pinnar kvar.."); }

                // ComputerPlayer spelar..
                removedPins = cpu.TakePins(board);
                remainingPins = board.GetNoPins();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{cpuName} har tagit bort {removedPins} pinnar!");
                Console.ResetColor();

                if (remainingPins == 0)
                {
                    didUserWin = false;
                    break;
                }
                else { Console.WriteLine($"\nDet finns {remainingPins} pinnar kvar.."); }
            }

            // Resultat för vem som vann
            if (didUserWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGrattis {humanName}! Du vann över {cpuName}. Bra jobbat!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nOuch! Ledsen {humanName}, men denna gång vann {cpuName}..");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
