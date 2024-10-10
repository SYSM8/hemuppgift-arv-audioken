namespace Hemuppgift_Arv_Temp.Game
{
    public abstract class Player
    {
        // Egenskap som hanterar spelarnas namn
        public string UserID { get; set; }

        // Konstruktor som sätter namnet på "UserID" när spelarna skapas
        public Player(string UserID)
        {
            this.UserID = UserID;
        }

        // Returnerar spelarens namn
        public string GetUserID()
        {
            return UserID;
        }

        public abstract int TakePins(Board board);
    }
}
