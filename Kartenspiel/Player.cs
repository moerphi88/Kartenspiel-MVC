using System;

namespace Kartenspiel
{

    public class Player
    {
        private Card c1, c2;
        private string _name;

        public Player(string name, Card _c1, Card _c2)
        {
            c1 = _c1;
            c2 = _c2;
            _name = name;
        }

        // Mit dieser Funktion soll herausgefunden werden, ob der Nutzer gewonnen hat (D.h. ob er zwei Asse auf der Hand hat)
        public bool IsWinner()
        {
            if (c1.Zahl == c2.Zahl)
                if (c1.Zahl == "As")
                    return true;
            return false; //Wenn keine der Abfragen wahr ist
        }

        // Diese Funktion wird benutzt, wenn der nutzer eine neue Karte ziehen soll. Nachdem er eine karte abgelegt hat.
        public Card MakeMove(int cardNo, Card c)
        {
            Card temp;

            switch (cardNo)
            {
                case 1:
                    temp = c1;
                    c1 = c;
                    break;
                case 2:
                    temp = c2;
                    c2 = c;
                    break;
                default:
                    temp = null;
                    Console.Error.WriteLine("Dieser Fall sollte nicht eintreten");
                break;
            }

            return temp;
        }

        //ToDo
        public string ShowHand()
        {
           return _name + " deine Hand:" + System.Environment.NewLine + "Karte 1: " +c1.ToString() + System.Environment.NewLine + "Karte 2: " + c2.ToString() + System.Environment.NewLine;
        }

    }
}