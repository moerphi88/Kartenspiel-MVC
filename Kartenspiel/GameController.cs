using System;

namespace Kartenspiel
{

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
}