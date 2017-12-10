using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System.Threading.Tasks;

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
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                WindowTitle = "MvvmSample (Design)";
                Progress = 30;
            }
            else
            {
                DispatcherHelper.Initialize();
                WindowTitle = "MvvmSample";
                Task.Run(
                    () =>
                    {
                        Task.Delay(2000).ContinueWith(
                                    t =>
                                    {
                                        while (Progress < 100)
                                        {
                                            DispatcherHelper.RunAsync(() => Progress += 5);
                                            Task.Delay(500).Wait();
                                        }
                                    });
                    });
                
            }
        }

        public string WindowTitle { get; private set; }
        public int Progress { get; set; }
    }
}