using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPMathGame.ViewModels;
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

namespace UWPMathGame.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayAdvanced : Page
    {
        private Random randomMath = new Random();
        private int Score = 0, State = 1, highScore, staticNumA, staticNumB, staticResult;
        private int difficulty = 1;
        private DispatcherTimer dispatcherTimer;
        private ScoreManagerViewModel scoreManagerVM;

        void setupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;
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

        public PlayAdvanced()
        {
            this.InitializeComponent();
        }

        private int randomNumber()
        {
            return randomMath.Next(1, 9);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlayAdvanced_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayAdvanced_BackRequested;
            scoreManagerVM = new ScoreManagerViewModel();
            highScore = scoreManagerVM.Get(difficulty);
            txtHighScore.Text = String.Format("HIGH:{0}",highScore);
            dispatcherTimer = null;
            Playing();
        }
        private int randomMathValue()
        {
            return randomMath.Next(0,3); //0:+ , 1:-, 2:*, 3:/
        }

        private void Playing()
        {
            int numberA = randomNumber();
            int numberB = randomMath.Next(0, numberA -1);
            int mathValue = randomMathValue();
            int result = 1;

            if(mathValue == 0)
                result = numberA + numberB;
            else if (mathValue == 1)
                result = numberA - numberB;
            else if (mathValue == 2)
                result = numberA * numberB;
            else 
                result = numberA / numberB;

            staticNumA = numberA;
            staticNumB = numberB;
            staticResult = result;
            txtMath.Text = String.Format("{0} ... {1} = {2}", staticNumA, staticNumB, staticResult);

            setupProgressBar();
        }

        private async void PlayAdvanced_BackRequested(object sender, BackRequestedEventArgs e)
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
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore});
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if(staticNumA + staticNumB == staticResult)
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

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (staticNumA - staticNumB == staticResult)
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

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            if (staticNumA * staticNumB == staticResult)
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

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (staticNumA / staticNumB == staticResult)
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
            catch(DivideByZeroException)
            {
                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }
    }
}
