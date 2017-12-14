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
        public Player p1 = new Player("Hussein", new Card(), new Card());
        public Player p2 = new Player("Hans", new Card(), new Card());

        public Player ReturnPlayerOne()
        {
            return p1;
        }

        public Player ReturnPlayerTwo()
        {
            return p2;
        }

        public void startGame()
        {
            p1.MakeMove(1, new Card("Herz", "Ass"));
            p2.MakeMove(2, new Card("Kreuz", "Neun"));
        }
    }
}