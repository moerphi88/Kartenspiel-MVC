using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartenspielWPF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Kartenspiel.GameModel gm = new Kartenspiel.GameModel();
            Form1 view = new Form1(gm);
            Kartenspiel.GameController gc = new Kartenspiel.GameController(gm, view);
            gc.StartGame();
            Application.Run(view);
        }
    }
}
