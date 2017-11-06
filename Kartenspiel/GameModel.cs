using System;

namespace Kartenspiel
{

    public class GameModel{

        private Player p1, p2;
        private CardDeck cd;
        private int activePlayer;
        private Card lastDroppedCard;
        private int round;
        private int winner;

        public Card LastDroppedCard
        {
            get { return lastDroppedCard; }
            set { lastDroppedCard = value; }
        }
        public int Winner
        {
            get { return winner; }
            set { winner = value; }
        }

        public int Round
        {
            get { return round; }
            set { round = value; }
        }

        public GameModel()
        {
            cd = new CardDeck();
            p1 = new Player("Spieler 1",cd.GetFirstCard(),cd.GetFirstCard());
            p2 = new Player("Spieler 2",cd.GetFirstCard(),cd.GetFirstCard());            
            activePlayer = 1;
            lastDroppedCard = null;
            round = 0;
        }

        // ToDo  Brauch ich diese noch? Wenn ich den aktiven Spieler eh über Toggle wechsel?
        public int ActivePlayer
        {
            get { return activePlayer; }
            set { activePlayer = value; }
        }

        public void ToggleActivePlayer()
        {
            activePlayer = (activePlayer == 1) ? 2 : 1;
        }

        public string ShowPlayersHand()
        {
            switch (activePlayer)
            {
                case 1:
                    return p1.ShowHand();
                case 2:
                    return p2.ShowHand();
                default:
                    return String.Empty;
            }
        }

        // Nachdem der nutzer eine Karte zum ablegen gewählt hat, wird diese Karte abgelegt und eine neue Karte wird vom Stapel auf die Hand genommen.
        public void PlayerMakesMove(int usersChoiceHandCard)
        {
            switch (activePlayer)
            {
                case 1:
                    lastDroppedCard = p1.MakeMove(usersChoiceHandCard,cd.GetFirstCard());
                    break;
                case 2:
                    lastDroppedCard = p2.MakeMove(usersChoiceHandCard, cd.GetFirstCard());
                    break;
            }
        }

        public bool isGameOver()
        {
            if (cd.isEmpty())
            {
                return true;
            }
            if (p1.IsWinner())
            {
                winner = 1;
                return true;
            }
            else if (p2.IsWinner())
            {
                winner = 2;
                return true;
            }
            else return false;
        }
    }
}