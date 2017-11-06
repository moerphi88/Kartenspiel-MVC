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
            Kartenspiel.GameView gv = new Kartenspiel.GameView(gm);
            Form1 view = new Form1();
        // Form1 kann ich natürlich nicht an den Controller übergeben. Hierfür muss ich erst ein Interface anlegen. Davon müssen GameView und Form1 das Interface extenden.
            Kartenspiel.GameController gc = new Kartenspiel.GameController(gm, gv);

            Application.Run(view);


        }
    }
}
