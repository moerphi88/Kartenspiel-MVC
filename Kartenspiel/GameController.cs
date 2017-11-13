using System;

namespace Kartenspiel
{

    public class GameController {
        private GameModel _model;
        private IGameView _view;

        private int _state;
        private int _selectedHandCard = 0;

        public GameController(GameModel model, IGameView view)
        {
            _model = model;
            _view = view;
        }

        //represents the state machein
        public void PlayRound()
        {
            try
            {
                switch (_state)
                {
                    case 0: //Initialschritt
                        UpdateView();
                        _state = 1;
                        break;
                    case 1: //Make move
                        _selectedHandCard = Convert.ToInt32(_view.GetUserInput());
                        _model.PlayerMakesMove(_selectedHandCard);
                        _model.ToggleActivePlayer();

                        //Wenn wieder der erste Spieler dran ist, muss wohl eine RUnde rum sein
                        if (_model.ActivePlayer == 1) _model.Round++;

                        if (_model.isGameOver())
                            _state = 2;
                        else
                            _state = 1;

                        break;
                    case 2: //Announce Winner
                        _view.AccounceWinner();
                        break;
                    default:
                        Console.Error.WriteLine("This shouldn´t happen");
                        break;
                }
            } catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        // Hier hatte das Beispiele ein paar Get und Set Methoden um direkt auf die Props von Card zuzugreifen
        public void StartGame()
        {           
            try
            {
                _state = 0; //inital state
                _selectedHandCard = 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public void UpdateView()
        {
            _view.UpdateView();
        }
    }
}