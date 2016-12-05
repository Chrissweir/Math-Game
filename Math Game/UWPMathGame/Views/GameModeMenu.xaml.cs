using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPMathGame.Views
{
    //This class is a simple class, it holds click events for the menu buttons Noraml, Advanced, and Settings.
    public sealed partial class GameModeMenu : Page
    {
        //Constructor
        public GameModeMenu()
        {
            this.InitializeComponent();
        }
        //End Constructor

        //Click event handler to the normal difficulty button
        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayNormal));
        }

        //Click event handler to the advanced difficulty button
        private void btnAdvanced_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayAdvanced));
        }

        //Click event handler to the settings difficulty button
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }
    }
}
