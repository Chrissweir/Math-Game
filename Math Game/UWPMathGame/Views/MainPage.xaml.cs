using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPMathGame.Views
{
    //This class is simple enough it is the logic for the Main(Home) page of the application.
    //It contains a click events to handle the play button which will bring the user onto the GameModeMenu page.
    public sealed partial class MainPage : Page
    {
        //Constructor
        public MainPage()
        {
            this.InitializeComponent();
        }
        //End Constructor

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= MainPage_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private async void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            //If the user tries to exit the application asks are they sure
            e.Handled = true;
            var msg = new MessageDialog("Do you want to exit?");
            var okBtn = new UICommand("Yes");
            var cancelBtn = new UICommand("No");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(cancelBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                Application.Current.Exit();
            }

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
                Frame.Navigate(typeof(GameModeMenu));
        }
    }
}
