/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Ui.Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Kartenspiel;
using System;
using System.Collections.Generic;

namespace Logic.Ui
{
    public class DataService : IDataService
    {
        private List<Player> listOfPlayers;
        private CardDeck cardDeck;
        private int activePlayer;

        public DataService()
        {
            activePlayer = 1;
            cardDeck = new CardDeck();
            listOfPlayers = new List<Player>();

            listOfPlayers.Add(new Player("Hussein", cardDeck.GetFirstCard(), cardDeck.GetFirstCard()));
            listOfPlayers.Add(new Player("Hans", cardDeck.GetFirstCard(), cardDeck.GetFirstCard()));
        }

        public int GetActivePlayer()
        {
            return activePlayer;
        }

        public GameStatus MakeMove(int usersChoice)
        {
            try
            {
                //wenn der Kartenstapel noch nicht leer ist
                if (!cardDeck.isEmpty())
                {
                    switch (activePlayer)
                    {
                        case 1:
                            listOfPlayers[0].ChangeHandCard(usersChoice, cardDeck.GetFirstCard());
                            if (IsWinner()) return GameStatus.Winner;                            
                            ToggleActivePlayer();
                            break;
                        case 2:
                            listOfPlayers[1].ChangeHandCard(usersChoice, cardDeck.GetFirstCard());
                            if (IsWinner()) return GameStatus.Winner;
                            ToggleActivePlayer();
                            break;
                    }
                    return GameStatus.Success;
                } else // Das Kartendeck ist leer. Dann ist das Spiel vorbei und es gibt keinen Gewinner
                {
                    return GameStatus.GameOver;
                }
            } catch (Exception e)
            {                
                System.Console.Error.WriteLine(e.Message);
                return GameStatus.GameOver;
            }
        }

        private bool IsWinner()
        {
            foreach(var p in listOfPlayers)
            {
                if (p.IsWinner())
                {
                    return true; 
                }
            }
            return false;
        }

        private void ToggleActivePlayer()
        {
            activePlayer = (activePlayer == 1) ? 2 : 1;
        }

        public List<Player> ReturnPlayer()
        {
            return listOfPlayers;
        }

        //Wird genutzt um das Spiel von neuem starten zu können.
        public void startGame()
        {
            cardDeck = new CardDeck();
            listOfPlayers.Clear();
            activePlayer = 1;

            listOfPlayers.Add(new Player("Hussein", cardDeck.GetFirstCard(), cardDeck.GetFirstCard()));
            listOfPlayers.Add(new Player("Hans", cardDeck.GetFirstCard(), cardDeck.GetFirstCard()));

        }
    }
}