using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartenspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card();
            CardView cv = new CardView(c);

            CardController cc = new CardController(c, cv);

            cc.startGame();

            Console.Read();
        }
    }

    enum Farbe { Herz, Karo, Pik, Kreuz};
    enum Wert { Sieben, Acht, Neun, Zehn, Bauer, Dame, Koenig, As};

    public class Card
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _zahl;

        public string Zahl
        {
            get { return _zahl; }
            set { _zahl = value; }
        }

        public Card(){
            Name = Farbe.Herz.ToString();
            Zahl = Wert.Acht.ToString();
        }

        public Card(string name, string zahl){
            Name = name;
            Zahl = zahl;
         }

    }

    // Test eines Kartenstapels. Wie genau kann ich denn nu eigentlich einzelne Elemten in der Liste verändern?
    public class CardDeck
    {
        List<Card> list;

        public CardDeck()
        {
            list = new List<Card>();
            list.Add(new Card("Pik", "Neun"));
            list.Add(new Card("Herz", "As"));
            list.Add(new Card("Kreuz", "Acht"));
            list.Add(new Card("Karo", "Sieben"));
        }

        public Card GetFirstCard()
        {
            Card c = new Card();
            try
            {
                c = list.ElementAt(0);
                list.RemoveAt(0);
                return c;

            }catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return null;                 
        }
    }

    public class CardView
    {
        Card _model;

        public CardView(Card model)
        {
            _model = model;
        }

        public void WriteCardDate()
        {
            Console.Clear();
            Console.WriteLine("Kartenname: {0} und Kartenwert: {1}", _model.Name, _model.Zahl);
        }

    }

    public class CardController { 
        private Card _model;
        private CardView _view;

        public CardController(Card model, CardView view)
        {
            _model = model;
            _view = view;
        }

        // Hier hatte das Beispiele ein paar Get und Set Methoden um direkt auf die Props von Card zuzugreifen
        public void startGame()
        {
            try
            {
                do
                {
                    updateView();
                    Console.WriteLine("Geben Sie einen Name ein:");
                    _model.Name = Console.ReadLine();
                    Console.WriteLine("Geben Sie einen Wert ein:");
                    _model.Zahl = Console.ReadLine();
                } while (!isWinner());
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private bool isWinner()
        {
            if (_model.Zahl == Wert.Neun.ToString())
                return true;
            else
                return false;
        }

        public void updateView()
        {
            _view.WriteCardDate();
        }
    }

}
