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
            GameModel gm = new GameModel();
            GameView gv = new GameView(gm);

            GameController gc = new GameController(gm, gv);

            gc.startGame();

            Console.Read();
        }
    }

    enum Farbe { Herz, Karo, Pik, Kreuz };
    enum Wert { Sieben, Acht, Neun, Zehn, Bauer, Dame, Koenig, As };

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

        public Card() {
            Name = Farbe.Herz.ToString();
            Zahl = Wert.Acht.ToString();
        }

        public Card(string name, string zahl) {
            Name = name;
            Zahl = zahl;
        }

        public override string ToString()
        {
            return Name + " " + Zahl;
        }


    }

    // Test eines Kartenstapels. Wie genau kann ich denn nu eigentlich einzelne Elemten in der Liste verändern?
    public class CardDeck
    {
        List<Card> list;
        Random random = new Random();

        private void InitCardDeck()
        {
            foreach(var value in Enum.GetNames(typeof(Farbe)))
                {
                foreach (var value2 in Enum.GetNames(typeof(Wert)))
                {
                    list.Add(new Card(value, value2));
                }
            }
        }

        public void ShuffleCardDeck()
        {
            List<Card> tempList = new List<Card>();

            for(int i = 0; i < list.Count; i++)
            {
                var ran = random.Next(31);
                tempList.Add(list.ElementAt(ran));
            }
            list = tempList;
        }

        public CardDeck()
        {
            list = new List<Card>();
            InitCardDeck();
            ShuffleCardDeck();
        }

        public bool isEmpty()
        {
            if (list.Count <= 1) return true; //Wenn nur noch eine Karte im Deck übrig ist, kann keine ganze runde mehr gespielt werden. Darum <= 1 und nicht nur 0.
            else return false;
        }

        public Card GetFirstCard()
        {
            Card c = new Card();
            try
            {
                c = list.ElementAt(0);
                list.RemoveAt(0);
                return c;

            } catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return null;
        }
    }

    public class GameView
    {
        GameModel _model;

        public GameView(GameModel model)
        {
            _model = model;
        }

        public void ÚpdateView()
        {
            Console.Clear();
            if (null != _model.LastDroppedCard) Console.WriteLine("Auf dem Ablagestapel liegt {0}", _model.LastDroppedCard);
            Console.WriteLine("Runde {0}", _model.Round);
            Console.WriteLine(_model.ShowPlayersHand());
        }

        public string GetUserInput()
        {
            Console.WriteLine("Spieler {0} Welche Karte möchtest du ablegen?",_model.ActivePlayer);
            return Console.ReadLine(); // Hier muss noch die Logik rein, dass nur gültige Werte eingegeben werden können.
        }

        public void AnnounceWinner()
        {
            if(_model.Winner == 0)
                Console.WriteLine("Es gibt keinen Gewinner!");
            else
                Console.WriteLine("Spieler {0} hat das Spiel gewonnen", _model.Winner);
        }


    }

    public class GameController {
        private GameModel _model;
        private GameView _view;

        public GameController(GameModel model, GameView view)
        {
            _model = model;
            _view = view;
        }

        // Hier hatte das Beispiele ein paar Get und Set Methoden um direkt auf die Props von Card zuzugreifen
        public void startGame()
        {
            int selectedHandCard = 0;
            try
            {
                do
                {
                    updateView();
                    selectedHandCard = Convert.ToInt32(_view.GetUserInput());
                    _model.PlayerMakesMove(selectedHandCard);
                    _model.ToggleActivePlayer();
                    updateView();
                    selectedHandCard = Convert.ToInt32(_view.GetUserInput());
                    _model.PlayerMakesMove(selectedHandCard);
                    _model.ToggleActivePlayer();
                    //temp = temp ? false : true;
                    _model.Round++;
                } while (!_model.isGameOver());
                _view.AnnounceWinner();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public void updateView()
        {
            _view.ÚpdateView();
        }
    }

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
           return _name + " deine Hand:" + "\n" + "Karte 1: " +c1.ToString() + "\nKarte 2: " + c2.ToString() +"\n";
        }

    }

    public class GameModel{

        private Player p1, p2;
        private CardDeck cd;
        private int activePlayer;
        private Card lastDroppedCard; //Wird auch noch garnicht verwendet!
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
