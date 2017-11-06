using System;

namespace Kartenspiel
{

    public class GameController {
        private GameModel _model;
        private IGameView _view;

        public GameController(GameModel model, IGameView view)
        {
            _model = model;
            _view = view;
        }

        // Hier hatte das Beispiele ein paar Get und Set Methoden um direkt auf die Props von Card zuzugreifen
        public void StartGame()
        {
            int selectedHandCard = 0;
            try
            {
                do
                {
                    UpdateView();
                    selectedHandCard = Convert.ToInt32(_view.GetUserInput());
                    _model.PlayerMakesMove(selectedHandCard);
                    _model.ToggleActivePlayer();
                    UpdateView();
                    selectedHandCard = Convert.ToInt32(_view.GetUserInput());
                    _model.PlayerMakesMove(selectedHandCard);
                    _model.ToggleActivePlayer();
                    //temp = temp ? false : true;
                    _model.Round++;
                } while (!_model.isGameOver());
                _view.AccounceWinner();
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