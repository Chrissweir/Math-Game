using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPMathGame.ViewModels;
using UWPMathGame.Models;
using System.Diagnostics;

namespace UWPMathGame.Views
{
    // This class is responsible for executing all the logic that goes into the normal difficulty
    // of the game itself. It contains methods for creating the equation questions, starting and 
    // stopping the timer, incrementing score, setting game defaults, click event handlers for 
    // true and false buttons, and many others.
    public sealed partial class PlayNormal : Page
    {
        private int staticNumA, staticNumB, staticResult, staticRandomResult, Score = 0, State = 1, highScore;
        public int mode;
        private int difficulty = 0;
        private DispatcherTimer dispatcherTimer;
        private ScoreManagerViewModel scoreManagerVM;

        //Setup the progressbar
        private void setupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;
        }

        //Click event handler for the false button
        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            //If the answer is correct then add to score and play again. If not go to the GameOver page
            if (mode <=5) 
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

        //When the user navigates to this page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayNormal_BackRequested;
            //Get the current highscore from the database depending on the current difficulty
             scoreManagerVM = new ScoreManagerViewModel();
            highScore = scoreManagerVM.Get(difficulty);
            txtHighScore.Text = String.Format("HIGH:{0}", highScore);
            dispatcherTimer = null;
            //Start the game
            Playing();
        }

        //If the user tries to exit the application asks are they sure
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

        //Progressbar timer tick rate
        private void DispatcherTimer_Tick(object sender, object e)
        {
            //Get the spped variable from the database
            scoreManagerVM = new ScoreManagerViewModel();
            //Subtract the value of the progressbar by the speed variable
            progressBar.Value -= scoreManagerVM.GetSpeed();
            //If the progressbar reaches 0 then launch the GameOver page and pass the score, highscore and difficulty to ScorePasser
            if (progressBar.Value <= 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;

                Frame.Navigate(typeof(GameOver), new ScorePasser { difficulty = difficulty, score = Score, highScore = highScore });
            }
        }

        //Constructor
        public PlayNormal()
        {
            this.InitializeComponent();
        }
        //End Constructor

        //Click event handler for true button
        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            //If the answer is correct then add to score and play again. If not go to the GameOver page
            if (mode >5) 
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
        
        //Play the game
        public void Playing()
        {
            //Random value to determine operation
            Random rd = new Random();
            int value = rd.Next(1, 4);

            //If value == 1 then + operator is used
            if(value == 1)// +
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA + staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(1, 9); //Random mode show answer. if mode = 0 show incorrect result
                if (mode <=5)
                {
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                {
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticResult);
                }
                    
            }

            //If value == 2 then - operator is used
            if (value == 2)// -
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA - staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(1, 9);  //Random mode show answer. if mode = 0 show incorrect result
                if (mode <= 5)
                {
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                {
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticResult);
                }
            }

            //If value == 3 then * operator is used
            if (value == 3)// *
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(0, staticNumA - 1);
                staticResult = staticNumA * staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(1, 9);  //Random mode show answer. if mode = 0 show incorrect result
                if (mode <=5)
                {
                    txtMath.Text = String.Format("{0} * {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                {
                    txtMath.Text = String.Format("{0} * {1} = {2}", staticNumA, staticNumB, staticResult);
                }
            }

            //If value == 4 then / operator is used
            if (value == 4)// /
            {
                staticNumA = rd.Next(1, 9);
                staticNumB = rd.Next(1, staticNumA);
                staticResult = staticNumA / staticNumB;
                staticRandomResult = rd.Next(1, 99);

                mode = rd.Next(1, 9);  //Random mode show answer. if mode = 0 show incorrect result
                if (mode <= 5)
                {
                    txtMath.Text = String.Format("{0} / {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                {
                    txtMath.Text = String.Format("{0} / {1} = {2}", staticNumA, staticNumB, staticResult);
                }
            }
            //Setup the progress bar
            setupProgressBar();
        }
    }
}
