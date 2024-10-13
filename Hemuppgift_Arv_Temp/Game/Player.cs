namespace Hemuppgift_Arv_Temp.Game
{
    // Superklass för att spelare
    public abstract class Player
    {
        // Spelarnas namn
        public string UserID { get; set; }

        // Initierar spelarna med namn
        public Player(string UserID)
        {
            this.UserID = UserID;
        }

        // Returnerar spelarnas namn
        public string GetUserID()
        {
            return UserID;
        }

        // Implementeras av subklasser för att ta bort pinnar
        public abstract int TakePins(Board board);
    }
}
