using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartenspielWPF
{
    public partial class Form1 : Form,Kartenspiel.IGameView
    {
        Kartenspiel.GameModel _model;

        public Form1(Kartenspiel.GameModel model)
        {
            _model = model;
            InitializeComponent(); 
        }

        public void AccounceWinner()
        {
            if (_model.Winner == 0)
                textBox2.Text += "Es gibt keinen Gewinner!" + System.Environment.NewLine;
            else
                textBox2.Text += "Spieler " + _model.Winner.ToString() + " hat das Spiel in Runde " + _model.Round.ToString() + " gewonnen";
        }

        public string GetUserInput()
        {
            var temp = "1";
            temp = (temp == "1") ? "2" : "1";
            
            return temp;
        }

        public void UpdateView()
        {
            if (null != _model.LastDroppedCard) textBox2.Text = "Auf dem Ablagestapel liegt " + _model.LastDroppedCard.ToString() + System.Environment.NewLine;
            textBox2.Text += "Runde " +_model.Round.ToString() + System.Environment.NewLine;
            textBox2.Text += _model.ShowPlayersHand() + System.Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
