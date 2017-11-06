using System;

namespace Kartenspiel
{

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
            Console.Clear();
            if(_model.Winner == 0)
                Console.WriteLine("Es gibt keinen Gewinner!");
            else
                Console.WriteLine("Spieler {0} hat das Spiel in Runde {1} gewonnen", _model.Winner, _model.Round);
        }


    }
}