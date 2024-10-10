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
            int noPins = 0;
            Board board = new Board();

            // Testar SetUp och GetNoPins
            board.SetUp(10); // Ställer in spelet att ha 10 pinnar
            noPins = board.GetNoPins(); // Kollar antal pinnar i spelet
            Console.WriteLine($"Antal pinnar i spelet är {noPins}!");

            // Testar TakePins och GetNoPins
            board.TakePins(2); // Tar bort 2 pinnar från det totala antalet
            noPins = board.GetNoPins(); // Kollar antal pinnar i spelet
            Console.WriteLine($"Antal pinnar som återstår är {noPins}!");
        }
    }
}
