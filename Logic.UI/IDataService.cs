﻿/*
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
    public interface IDataService
    {
        void startGame();
        Player ReturnPlayerOne();
        Player ReturnPlayerTwo();
    }
}