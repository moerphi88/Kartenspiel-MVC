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

namespace Logic.Ui
{
    public class DataService : IDataService
    {
        public Player ReturnPlayerOne()
        {
            return new Player("Hussein", new Card(), new Card());
        }

        public Player ReturnPlayerTwo()
        {
            return new Player("Hans", new Card(), new Card());
        }

        public void startGame()
        {
            throw new System.NotImplementedException();
        }
    }
}