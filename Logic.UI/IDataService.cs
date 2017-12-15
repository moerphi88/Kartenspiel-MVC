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
using System.Collections.Generic;

namespace Logic.Ui
{
    public enum GameStatus {Success, GameOver, Winner};

    public interface IDataService
    {
        int GetActivePlayer();
        void startGame();
        List<Player> ReturnPlayer();
        GameStatus MakeMove(int i);
    }
}