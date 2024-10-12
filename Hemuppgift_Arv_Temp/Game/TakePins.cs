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
            // START
            WelcomeScreen();

            // Spelinställningar
            Player user = new HumanPlayer(ChooseUserName()); // Skapar "Player" med en instans från "HumanPlayer"
                                                             // Parametern returnerar ett valt användarnamn

            string userName = user.GetUserID(); // Lagrar namnet i variabel för tydligare utskrifter

            Player cpu = ChooseOpponent(userName); // Skapar "Player" baserat på vald motståndare
                                                   // Använder "userName" för utskrift i metoden

            string cpuName = cpu.GetUserID(); // Lagrar namnet i ny variabel för tydligare utskrifter

            int numberOfPins = ChooseNumberOfPins(cpuName); // Lagrar valt antal pinnar, använder "cpuName" för utskrift i metoden

            // Skapar spelplan
            Board board = new Board();

            // Ställer in antalet pinnar för spelplanen
            board.SetUp(numberOfPins);

            // Spelmekanik
            int removedPins = 0;

            bool userTurn = true;
            bool didUserWin = false;

            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("              SPELET ÄR IGÅNG..              ");
            Console.WriteLine("=============================================");

            while (numberOfPins != 0)
            {
                VisualizePins(numberOfPins);

                if (userTurn)
                {
                    // Användarens tur
                    removedPins = user.TakePins(board); // Lagra antalet borttagna pinnar

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[{userName}] har tagit bort {removedPins} pinnar!");
                    Console.ResetColor();
                }
                else
                {
                    // Simulerar betänktetid för vald datormotståndare
                    ProcessingSimulator(cpuName);

                    // Datorns tur
                    removedPins = cpu.TakePins(board);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n\n[{cpuName}] har tagit bort {removedPins} pinnar!");
                    Console.ResetColor();
                }

                numberOfPins = board.GetNoPins(); // Lagra antalet återstående pinnar

                // Vinstkontroll
                if (numberOfPins == 0)
                {
                    if (userTurn)
                        didUserWin = true;
                    else
                        didUserWin = false;
                    break;
                }

                userTurn = !userTurn;

                Console.WriteLine("\n=============================================");
            }

            // Slutresultat
            EndResult(didUserWin, userName, cpuName);
        }

        static void WelcomeScreen()
        {
            Console.Clear();

            // Välkomnar användaren med instruktioner
            Console.WriteLine("=============================================");
            Console.WriteLine("======= VÄLKOMMEN TILL PINN OR LOOSE! =======");
            Console.WriteLine("=============================================");
            Console.WriteLine();
            Console.WriteLine("* Det ligger ett antal stickor på ett bord. ");
            Console.WriteLine("* Två spelare turas om att ta stickor.");
            Console.WriteLine("* Man får ta en eller två stickor.");
            Console.WriteLine("* Den som tar sista stickan vinner.");
            Console.WriteLine();
            Console.WriteLine("=============================================");

            Console.Write("\nTryck på valfri tangent för att fortsätta..");
            Console.ReadKey();
        }

        static string ChooseUserName()
        {
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                ANVÄNDARNAMN                 ");
            Console.WriteLine("=============================================");
            Console.Write("\nVälj ditt användarnamn: ");

            string userName = Console.ReadLine();

            return userName;
        }

        static Player ChooseOpponent(string humanName)
        {
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                 MOTSTÅNDARE                 ");
            Console.WriteLine("=============================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDu har valt användarnamnet [{humanName}].");
            Console.ResetColor();

            do
            {
                Console.WriteLine("\nVälj din motståndare:");

                Console.WriteLine("\n[1] 3-CPO (Lätt)\n[2] Deep Thought (Svår)");

                Console.Write("\nDitt val: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        return new ComputerPlayer("3-CPO");

                    case "2":
                        return new ComputerPlayerHard("Deep Thought");

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..");
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }

        static int ChooseNumberOfPins(string cpuName)
        {
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                ANTAL PINNAR                 ");
            Console.WriteLine("=============================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nDu har valt att möta [{cpuName}]");
            Console.ResetColor();
            Console.WriteLine("\nHur många pinnar vill du att spelet ska ha?");

            do
            {
                Console.Write("\nVälj mellan 5-20: ");

                if (int.TryParse(Console.ReadLine(), out int numberOfPins) && numberOfPins >= 5 && numberOfPins <= 20)
                {
                    return numberOfPins;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste välja ett antal mellan 5-20..");
                    Console.ResetColor();
                }
            } while (true);
        }

        static void ProcessingSimulator(string cpuName)
        {
            // Datorns tur
            Console.Write($"\n[{cpuName}] processerar");

            // Simulerar datorns betänketid
            for (int i = 0; i < 6; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }

        static void EndResult(bool didUserWin, string userName, string cpuName)
        {
            if (didUserWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGrattis [{userName}]! Du vann över [{cpuName}]. Bra jobbat!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nOuch! Ledsen [{userName}], men denna gång vann [{cpuName}]..");
                Console.ResetColor();
            }
        }

        static void VisualizePins(int remainingPins)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nDet finns {remainingPins} pinnar kvar..\n");

            for (int i = 0; i < remainingPins; i++)
            {
                Console.Write(" |");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
