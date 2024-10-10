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
            Player human = new HumanPlayer("Human");
            Player cpu = new ComputerPlayer("CPU");

            // Deklarerar variabler för att öka läsbarheten i utskrifter
            int removedPins = 0;
            int remainingPins = 0;
            string humanName = human.GetUserID();
            string cpuName = cpu.GetUserID();

            // Tillfälligt val av antal pinnar i spelet
            board.SetUp(10);

            // Tillfällig loop för testning
            while (true)
            {
                // Människa väljer pinnar att ta bort
                removedPins = human.TakePins(board);
                remainingPins = board.GetNoPins();

                Console.WriteLine($"\n{humanName} har tagit bort {removedPins} pinnar!");
                Console.WriteLine($"\nDet finns {remainingPins} pinnar kvar..");

                // CPU väljer pinnar att ta bort
                removedPins = cpu.TakePins(board);
                remainingPins = board.GetNoPins();

                Console.WriteLine($"\n{cpuName} har tagit bort {removedPins} pinnar!");
                Console.WriteLine($"\nDet finns {remainingPins} pinnar kvar..");

                Console.ReadKey();
            }
        }
    }
}
