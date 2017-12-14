using System;
using System.Collections.Generic;

namespace Kartenspiel
{

    public class Player
    {
        private List<Card> cardList;
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public Player(string name, Card _c1, Card _c2)
        {
            cardList = new List<Card>();
            cardList.Add(_c1);
            cardList.Add(_c2);
            Name = name;
        }

        // Mit dieser Funktion soll herausgefunden werden, ob der Nutzer gewonnen hat (D.h. ob er zwei Asse auf der Hand hat)
        public bool IsWinner()
        {
            if (cardList[0].Zahl == cardList[1].Zahl)
                if (cardList[0].Zahl == "As")
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
                    temp = cardList[0];
                    cardList[0] = c;
                    break;
                case 2:
                    temp = cardList[1];
                    cardList[1] = c;
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
           return Name + " deine Hand:" + System.Environment.NewLine + "Karte 1: " + cardList[0].ToString() + System.Environment.NewLine + "Karte 2: " + cardList[1].ToString() + System.Environment.NewLine;
        }

        public List<Card> ReturnHandCards()
        {
            return cardList;
        }


    }
}