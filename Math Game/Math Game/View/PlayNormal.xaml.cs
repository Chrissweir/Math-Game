using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Math_Game.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayNormal : Page
    {
        private int staticNumA, staticNumB, staticResult, staticRandomResult,Score=0,State=1,BestScore=0,mode;
        private DispatcherTimer dispatcherTimer;

        private void setupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlayNormal_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayNormal_BackRequested;
            dispatcherTimer = null;
        }

        private async void PlayNormal_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            dispatcherTimer.Stop();
            dispatcherTimer = null;

            var msg = new MessageDialog("Do you want to Stop?");
            var okBtn = new UICommand("Yes");
            var cancelBtn = new UICommand("No");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(cancelBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                Frame.Navigate(typeof(GameOver),Score.ToString()); //Navigate to gameover page and send the score
            }
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            progressBar.Value -= Common.Common.Speed;
            if(progressBar.Value <= 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;

                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }

        public PlayNormal()
        {
            this.InitializeComponent();
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            if(mode == 1) // mode - 1 so correct answer is true
            {
                txtScore.Text = String.Format("Score:{0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;

                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }
    }
}
