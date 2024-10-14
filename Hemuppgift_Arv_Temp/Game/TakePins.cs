namespace Hemuppgift_Arv_Temp.Game
{
    internal class TakePins
    {
        /* SVAR PÅ FRÅGOR        
        ----------------------------------------------------------------------------------------------------------

         F2 a) Klassen Player är .............. till klasserna HumanPlayer och ComputerPlayer.
            
            Superklass, basklass

        ----------------------------------------------------------------------------------------------------------

         F2 b) Vilka av följande tilldelningssatser är korrekta? 
         
            Player p = new Player("Aegon");                    FEL     ("Player" är abstract)         
            Player p = new HumanPlayer("Alicent");             RÄTT    ("HumanPlayer" äver från "Player")
            HumanPlayer p = new HumanPlayer("Rhaenyra");       RÄTT    ("HumanPlayer" är inte abstrakt");
            HumanPlayer p = new ComputerPlayer("Aemond");      FEL     (Inga arv, separata klasser).

        ----------------------------------------------------------------------------------------------------------

         D4 a) I programmet för spelet dra stickor använder vi arv (superklassen Player och underklasserna 
               HumanPlayer och ComputerPlayer). Vad har vi vunnit med detta?

            Att kunna återanvända kod samt få möjligheten att skapa flera underklasser som bygger vidare på
            superklassen "Player".

        ----------------------------------------------------------------------------------------------------------

         D4 b) Det finns en abstrakt metod i superklassen Player. Vad är en abstrakt metod? Varför finns den där?

            En abstrakt metod saknar kod. Koden blir istället implementerad i de ärvande underklasserna.          
            
            Den finns där eftersom spelets funktionalitet är beroende av metoden som tar bort pinnar.     
            Genom att göra metoden abstrakt i basklassen "Player", tvingas de ärvande klasserna att 
            implementera den logik som krävs. Underklasser som "HumanPlayer" och "ComputerPlayer" har 
            därmed ett kontrakt med basklassen.

        ----------------------------------------------------------------------------------------------------------     
        */

        static void Main(string[] args)
        {
            bool playAgain = true; // Kontroll för att loopa om spelet

            while (playAgain)
            {
                // Startar spelet med välkomstskärm
                WelcomeScreen();

                // Skapar människostyrd spelare och lagrar namnet
                Player human = new HumanPlayer(ChooseHumanName()); // Metodparametern returnerar valt namn
                string humanName = human.GetUserID(); // Lagrar namnet för renare utskrifter

                // Skapar datorstyrd motståndare och lagrar namnet
                Player cpu = ChooseOpponent(); // Metoden returnar vald motståndare
                string cpuName = cpu.GetUserID(); // Lagrar namnet för renare utskrifter
                PrintOpponent(cpuName); // Utskrift som bekräftar val

                // Skapar och ställer in spelplanen
                Board board = new Board(); // Skapar objektet för spelplan
                int numberOfPins = ChooseNumberOfPins(); // Väljer antal pinnar för spelplan    
                board.SetUp(numberOfPins); // Ställer in antalet pinnar för spelplanen

                // Rensar konsolrutan
                Console.Clear();

                // Spelet startar
                Console.WriteLine("=============================================");
                Console.WriteLine("              SPELET ÄR IGÅNG..              ");
                Console.WriteLine("=============================================");

                int removedPins = 0; // För utskrift av borttagna pinnar
                bool isHumansTurn = true; // Människan börjar spelet. Även för vinstkontroll efter spelet.
                bool didHumanWin; // Utser vinnare

                // Loopar spelet tills alla pinnar är borttagna
                while (numberOfPins != 0)
                {
                    // Visualisera återstående pinnar
                    VisualizePins(numberOfPins);

                    // Människans tur
                    if (isHumansTurn)
                    {
                        Console.Write($"\n[{humanName}] ");

                        // Människa väljer antal pinnar att ta bort
                        removedPins = human.TakePins(board);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n[{humanName}] har tagit bort {removedPins} pinnar!");
                        Console.ResetColor();
                    }
                    // Datorns tur
                    else
                    {
                        // Simulerar betänktetid för vald datormotståndare
                        ProcessingSimulator(cpuName);

                        // Datorn genererar antal pinnar att ta bort
                        removedPins = cpu.TakePins(board);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\n[{cpuName}] har tagit bort {removedPins} pinnar!");
                        Console.ResetColor();
                    }

                    // Hämta återstående pinnar
                    numberOfPins = board.GetNoPins();

                    // Byt tur om det finns pinnar kvar
                    if (numberOfPins > 0)
                        isHumansTurn = !isHumansTurn;

                    Console.WriteLine("\n=============================================");
                }

                // Vinstkontroll när sista pinnen är borttagen
                if (isHumansTurn)
                    didHumanWin = true;
                else
                    didHumanWin = false;

                // Utskrift av slutresultat
                EndResult(didHumanWin, humanName, cpuName);

                // Frågar om användaren vill spela igen
                playAgain = PlayAgain(); // Lagrar svaret i en bool som kontrollerar hela spelets loop
            }
        }

        // Välkomnar användaren med instruktioner
        static void WelcomeScreen()
        {
            // Rensar konsolrutan
            Console.Clear();

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

            Console.Write("\nTryck på valfri tangent för att gå vidare..");

            // Väntar på nedtryckning av tangent för att gå vidare
            Console.ReadKey();
        }

        // Låter användaren välja namn på spelaren
        static string ChooseHumanName()
        {
            // Rensar konsolrutan
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                 SPELARRNAMN                 ");
            Console.WriteLine("=============================================");

            // Användaren väljer spelarnamn
            do
            {
                Console.Write("\nVälj namn för spelare: ");
                string? humanName = Console.ReadLine(); // Lagra inmatning i en sträng

                // Returnerar valt namn om det innehåller 3-10 tecken
                if (!String.IsNullOrWhiteSpace(humanName) && humanName.Length >= 3 && humanName.Length <= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\nSparar [{humanName}].. ");
                    Console.ResetColor();

                    // Fördröjning för att hinna läsa utskriften ovan innan konsolrutan rensas
                    Thread.Sleep(1500);

                    return humanName; // Returnera valt namn
                }
                // Felmeddelande - Användaren får försöka igen
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAnvänd mellan 3-10 tecken..");
                    Console.ResetColor();
                }

            } while (true); // Loopar tills korrekt inmatning skett
        }

        // Låter användaren välja sin motståndare
        static Player ChooseOpponent()
        {
            // Rensar konsolrutan
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                 MOTSTÅNDARE                 ");
            Console.WriteLine("=============================================");

            // Välj nivån på den datorstyrda motståndaren
            do
            {
                Console.WriteLine("\nVälj din motståndare:");

                Console.WriteLine("\n[1] 3-CPO (Lätt)\n[2] Deep Thought (Svår)");

                Console.Write("\nDitt val: ");

                // Läser in användarens inmatning
                switch (Console.ReadLine())
                {
                    case "1":
                        return new ComputerPlayer("3-CPO"); // Returnerar en lätt motståndare

                    case "2":
                        return new ComputerPlayerHard("Deep Thought"); // Returnerar en svår motståndare

                    // Felmeddelande - Användaren får försöka igen
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Loopar tills korrekt inmatning skett
        }

        // Utskrift för att bekräfta val av motståndare
        static void PrintOpponent(string cpuName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\nDu valde [{cpuName}].. ");
            Console.ResetColor();

            // Fördröjning för att hinna läsa utskriften ovan innan konsolrutan rensas
            Thread.Sleep(1500);
        }

        // Låter användaren välja antal pinnar för spelbrädet
        static int ChooseNumberOfPins()
        {
            // Rensar konsolrutan
            Console.Clear();

            Console.WriteLine("=============================================");
            Console.WriteLine("                ANTAL PINNAR                 ");
            Console.WriteLine("=============================================");

            Console.WriteLine("\nHur många pinnar vill du att spelet ska ha?");

            // Välj antal pinnar
            do
            {
                Console.Write("\nVälj mellan 5-20: ");

                // Returnerar antalet valda pinnar om inmatat värde är heltal mellan 5-20
                if (int.TryParse(Console.ReadLine(), out int numberOfPins) && numberOfPins >= 5 && numberOfPins <= 20)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\nDu valde {numberOfPins} pinnar.. ");
                    Console.ResetColor();

                    // Fördröjning för att hinna läsa utskriften ovan innan konsolrutan rensas
                    Thread.Sleep(1500);

                    return numberOfPins; // Returnera antalet pinnar
                }
                // Felmeddelande - Användaren får försöka igen
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste välja ett antal mellan 5-20..");
                    Console.ResetColor();
                }

            } while (true); // Loopar tills korrekt inmatning skett
        }

        // Visualiserar antalet pinnar kvar i spel för bättre användarupplevelse
        static void VisualizePins(int numberOfPins)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nDet finns {numberOfPins} pinnar kvar..\n");

            // Skriv ut tecknet "|" för varje pinne som är kvar i spelet
            for (int i = 0; i < numberOfPins; i++)
            {
                Console.Write(" |");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        // Simulerar en betänketid för datormotståndaren
        static void ProcessingSimulator(string cpuName)
        {
            Console.Write($"\n[{cpuName}] processerar");

            // Simulerar datorns betänketid
            for (int i = 0; i < 6; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }

        // Presenterar spelets slutresultat
        static void EndResult(bool didHumanWin, string humanName, string cpuName)
        {
            if (didHumanWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGrattis [{humanName}]! Du vann över [{cpuName}]. Bra jobbat!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nOuch! Ledsen [{humanName}], men denna gång vann [{cpuName}]..");
                Console.ResetColor();
            }
        }

        // Låter användaren spela igen eller avsluta
        static bool PlayAgain()
        {
            // Välj nivån på den datorstyrda motståndaren
            do
            {
                Console.WriteLine("\nVill du spela igen?");

                Console.WriteLine("\n[1] Ja\n[2] Nej, avsluta..");

                Console.Write("\nDitt val: ");

                // Läser in användarens inmatning
                switch (Console.ReadLine())
                {
                    case "1":
                        return true;

                    case "2":
                        return false;

                    // Felmeddelande - Användaren får försöka igen
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDu måste välja 1 eller 2..");
                        Console.ResetColor();
                        break;
                }

            } while (true); // Loopar tills korrekt inmatning skett

        }
    }
}
