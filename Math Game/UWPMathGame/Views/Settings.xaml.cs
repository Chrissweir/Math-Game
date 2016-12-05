using UWPMathGame.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;


namespace UWPMathGame.Views
{
    //This class is responible for changing the time speed setting of the game. 
    //The timer speed value is stored in the SQLite Database so this setting does 
    //not change when the app is closed. The class also contains navigation handler for the Back button.
    public sealed partial class Settings : Page
    {
        private ScoreManagerViewModel scoreManagerVM;

        //Constructor
        public Settings()
        {
            this.InitializeComponent();
        }
        //End Constructor

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= Option_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += Option_BackRequested;
            //Get the current speed from the database
            scoreManagerVM = new ScoreManagerViewModel();
            //slider value equal to the speed
            int sliderValue = scoreManagerVM.GetSpeed();
            slider.Value = sliderValue / 10;
        }

        private void Option_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        //When the slider value changes send the new value to the database
        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            scoreManagerVM = new ScoreManagerViewModel();
            int speedValue = int.Parse(slider.Value.ToString()) * 10;
            scoreManagerVM.SetSpeed(speedValue);
        }
        
        //CLick event handler for the back button
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameModeMenu));
        }
    }
}
