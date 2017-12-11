using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
                //SetSomeDateCommand = new RelayCommand(() =>
                //{
                //    System.Console.WriteLine("Hallo");
                //});
            }
            else
            {
                NameSpieler1 = "Hans";
                NameSpieler2 = "Hussein";
                WindowTitle = "Kartenspiel";
                SetSomeDateCommand = new RelayCommand(() =>
                {
                    System.Console.WriteLine("Hallo");
                    PasseKartenNamenAn();
                });
            }
        }

        private void PasseKartenNamenAn()
        {
            HandKarteEinsSpieler1 = _dataService.ReturnPlayerOne().ReturnFirstHandCard().ToString();
            HandKarteZweiSpieler1 = _dataService.ReturnPlayerOne().ReturnSecondHandCard().ToString();
            HandKarteEinsSpieler2 = _dataService.ReturnPlayerTwo().ReturnFirstHandCard().ToString();
            HandKarteZweiSpieler2 = _dataService.ReturnPlayerTwo().ReturnSecondHandCard().ToString();
        }

        private IDataService _dataService;
        public string WindowTitle { get; private set; }
        public string NameSpieler1 { get; set; }
        public string NameSpieler2 { get; set; }
        public string HandKarteEinsSpieler1 { get; set; }
        public string HandKarteZweiSpieler1 { get; set; }
        public string HandKarteEinsSpieler2 { get; set; }
        public string HandKarteZweiSpieler2 { get; set; }

        public RelayCommand SetSomeDateCommand { get; }

        

    }
}