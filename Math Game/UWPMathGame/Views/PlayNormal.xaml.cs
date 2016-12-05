using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.ViewModels;
using UWPMathGame.Models;

namespace UWPMathGame.Views
{
    public sealed partial class PlayNormal : Page
    {
        private int staticNumA, staticNumB, staticResult, staticRandomResult,Score=0,State=1,highScore,mode;
        private int difficulty = 0;
        private DispatcherTimer dispatcherTimer;
        private ScoreManagerViewModel scoreManagerVM;

        private void setupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;
        }

        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0) // mode = 1 so correct answer is true
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

                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlayNormal_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayNormal_BackRequested;
            scoreManagerVM = new ScoreManagerViewModel();
            highScore = scoreManagerVM.Get(difficulty);
            txtHighScore.Text = String.Format("HIGH:{0}", highScore);
            dispatcherTimer = null;

            Playing();
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
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            scoreManagerVM = new ScoreManagerViewModel();
            progressBar.Value -= scoreManagerVM.GetSpeed();
            if (progressBar.Value <= 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;

                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        public PlayNormal()
        {
            this.InitializeComponent();
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            if(mode == 1) // mode = 1 so correct answer is true
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

                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        private void Playing()
        {
            Random rd = new Random();
            int value = rd.Next(1, 4);
            if(value == 1)// +
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA + staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(0, 1); //Random mode show answer. if mode = 0 show incorrect result
                if (mode == 0)
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                else
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 2)// -
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA - staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(0, 1); //Random mode show answer. if mode = 0 show incorrect result
                if (mode == 0)
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                else
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 3)// *
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA * staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(0, 1); //Random mode show answer. if mode = 0 show incorrect result
                if (mode == 0)
                    txtMath.Text = String.Format("{0} * {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                else
                    txtMath.Text = String.Format("{0} * {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 4)// /
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(1, staticNumA);
                staticResult = staticNumA / staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(0, 1); //Random mode show answer. if mode = 0 show incorrect result
                if (mode == 0)
                    txtMath.Text = String.Format("{0} / {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                else
                    txtMath.Text = String.Format("{0} / {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            setupProgressBar();
        }
    }
}
