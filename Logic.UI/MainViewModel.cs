using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Kartenspiel;
using System;
using System.Collections.Generic;

namespace Logic.Ui
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {

            _dataService = dataService;

            if (IsInDesignMode)
            {
                WindowTitle = "Kartenspiel (Design)";
                NameSpieler1 = "Hans";
                NameSpieler2 = "Hussein";
                HandKarteEinsSpieler1 = "Herz Ass";
                HandKarteZweiSpieler1 = "Karo Ass";
                HandKarteEinsSpieler2 = "Kreuz Ass";
                HandKarteZweiSpieler2 = "Pik Ass";
                CanMakeMove = true;
                IsWinner = false;

                HandKarteEinsSpieler1 = "~/../../Images/herzzehn.png";
                HandKarteZweiSpieler1 = "~/../../Images/KreuzNeun.png";
                HandKarteEinsSpieler2 = "~/../../Images/KreuzSieben.png";
                HandKarteZweiSpieler2 = "~/../../Images/PikBube.png";
            }
            else
            {
                UpdateVM();

                InitialisiereVM();

                MakeMoveCommand = new RelayCommand<string>((s) =>
                {
                    int i;
                    int.TryParse(s, out i); //Die Eingabe des Textfeldes wird in ein Int geparsed. Hier muss noch eine Fehlerbehandlung hin. Außerdem muss sichergestellt werden, dass nur 1 oder 2 eingegeben werden.

                    var gameStatus = _dataService.MakeMove(i);
                    switch (gameStatus) {
                        case GameStatus.Success:
                            UpdateVM();
                            break;
                        case GameStatus.Winner:
                            UpdateVM();
                            CanMakeMove = false;
                            IsWinner = true;
                            break;
                        case GameStatus.GameOver:
                            CanMakeMove = false;
                            IsWinner = true;
                            break;
                    }
                    DetermineActivePlayer();
                });

                StartGameCommand = new RelayCommand(() =>
                {
                    InitialisiereVM();
                    _dataService.startGame();
                    UpdateVM();
                });
            }
        }
        private void InitialisiereVM()
        {
            NameSpieler1 = "Hans";
            NameSpieler2 = "Hussein";
            WindowTitle = "Kartenspiel";
            CanMakeMove = true;
            IsWinner = false;
            PlayerOneIsActive = _dataService.GetActivePlayer() != 1 ? false : true;
            PlayerTwoIsActive = !PlayerOneIsActive;
        }

        private void DetermineActivePlayer()
        {
            int activePlayer = _dataService.GetActivePlayer();
            switch (activePlayer)
            {
                case 1:
                    if (CanMakeMove) PlayerOneIsActive = true;
                    else PlayerOneIsActive = false;
                    PlayerTwoIsActive = !PlayerOneIsActive;
                    break;
                case 2:
                    if (CanMakeMove) PlayerTwoIsActive = true;
                    else PlayerTwoIsActive = false;
                    PlayerOneIsActive = !PlayerTwoIsActive;
                    break;
            }
        }

        private void UpdateVM()
        {
            List<Card> handCardsPlayerOne = _dataService.ReturnPlayer()[0].ReturnHandCards();
            List<Card> handCardsPlayerTwo = _dataService.ReturnPlayer()[1].ReturnHandCards();
            HandKarteEinsSpieler1 = "C:/Users/Johannes/Documents/Visual Studio 2017/Projects/Kartenspiel-MVC/Images/" + handCardsPlayerOne[0].ToString() + ".png";
            HandKarteZweiSpieler1 = "C:/Users/Johannes/Documents/Visual Studio 2017/Projects/Kartenspiel-MVC/Images/" + handCardsPlayerOne[1].ToString() + ".png";
            HandKarteEinsSpieler2 = "C:/Users/Johannes/Documents/Visual Studio 2017/Projects/Kartenspiel-MVC/Images/" + handCardsPlayerTwo[0].ToString() + ".png";
            HandKarteZweiSpieler2 = "C:/Users/Johannes/Documents/Visual Studio 2017/Projects/Kartenspiel-MVC/Images/" + handCardsPlayerTwo[1].ToString() + ".png";

        }

        private IDataService _dataService;
        public string WindowTitle { get; private set; }
        public string NameSpieler1 { get; set; }
        public string NameSpieler2 { get; set; }
        public string HandKarteEinsSpieler1 { get; set; }
        public string HandKarteZweiSpieler1 { get; set; }
        public string HandKarteEinsSpieler2 { get; set; }
        public string HandKarteZweiSpieler2 { get; set; }
        public bool CanMakeMove { get; set; }
        public bool IsWinner { get; set; }
        public bool PlayerOneIsActive { get; set; }
        public bool PlayerTwoIsActive { get; set; }

        public RelayCommand<string> MakeMoveCommand { get; }
        public RelayCommand StartGameCommand { get; }



    }
}