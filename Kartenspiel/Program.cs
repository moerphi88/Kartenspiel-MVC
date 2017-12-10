using System;

namespace Kartenspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            GameModel gm = new GameModel();
            GameView gv = new GameView(gm);

            GameController gc = new GameController(gm, gv);

            gc.StartGame();

            Console.Read();
        }
    }

    enum Farbe { Herz, Karo, Pik, Kreuz };

    enum Wert { Sieben, Acht, Neun, Zehn, Bauer, Dame, Koenig, As };


}
